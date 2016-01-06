using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;
using CalculationUnit.CalculationService;

namespace CalculationUnit
{
	public partial class CalculationUnitForm : Form, IВistributedСalculationCallback
	{
		private ВistributedСalculationClient client = null;

		public CalculationUnitForm()
		{
			InitializeComponent();
			this.Disposed += CalculationUnitForm_Disposed;
		}

		private void CalculationUnitForm_Disposed(object sender, EventArgs e)
		{
			if (this.client != null)
			{
				if (this.client.State == CommunicationState.Opened)
				{
					this.client.Close();
				}
			}
		}

		private void btnRememberMe_Click(object sender, EventArgs e)
		{
			if (this.client == null)
			{
				var context = new InstanceContext(this);
				this.client = new ВistributedСalculationClient(context);
				this.client.Open();
			}

			bool result = this.client.RememberCalculationUnit();
			RememberResult(result);
		}

		private void RememberResult(bool result)
		{
			this.txtLog.AppendText(string.Format("{0} -- {1}{2}", DateTime.Now, this.GetRememberMeMessage(result), Environment.NewLine));

			this.btnRememberMe.Enabled = !result;
		}

		private string GetRememberMeMessage(bool isSuccessfull)
		{
			return isSuccessfull ? "Успешное подключение к серверу" : "ОШИБКА при подключении к серверу, попробуйте еще раз";
		}

		#region IВistributedСalculationCallback Members

		public CalculationOutput Calculate(CalculationParameterForUnit input)
		{
			var res = new CalculationOutput() { Result = F(input.X) };

			this.txtLog.AppendText(string.Format(
@"{0} -- Информация {1}
Выполнен запрос на подсчет{1}
при х = {2}{1}
значение функции = {3}{1}
--------------------------------{1}", DateTime.Now, Environment.NewLine, input.X, res.Result));

			return res;
		}

		public bool Ping()
		{
			return true;
		}

		#endregion

		private long F(long x)
		{
			long result = x * x;

			return result;
		}

		private void btnRunYourself_Click(object sender, EventArgs e)
		{
			string myName = System.AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", "");
			Process.Start(myName);
		}
	}
}
