using System;
using System.ServiceModel;
using System.Windows.Forms;
using AskForCalculate.CalculationService;

namespace AskForCalculate
{
	public partial class AskForCalculationForm : Form, IВistributedСalculationCallback
	{
		private ВistributedСalculationClient client = null;

		private long Start
		{
			get
			{
				return ParseNumber(this.txtStart.Text);
			}
		}

		private long End
		{
			get
			{
				return ParseNumber(this.txtEnd.Text);
			}
		}

		private void SetResult(CalculationOutput result)
		{
			string message = string.IsNullOrWhiteSpace(result.Error) ? string.Format("Результат вычислений:{0}", result.Result) : string.Format("Произошла ошибка{0}", result.Error);
			this.SetMessage(message);
		}

		private long ParseNumber(string str)
		{
			long result;
			long.TryParse(str, out result);
			return result;
		}

		public AskForCalculationForm()
		{
			InitializeComponent();
			this.Disposed += AskForCalculationForm_Disposed;
		}

		private void AskForCalculationForm_Disposed(object sender, EventArgs e)
		{
			if (this.client != null)
			{
				this.client.Close();
			}
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			CalculateDate();
		}

		private async void CalculateDate()
		{
			if (this.client == null)
			{
				var context = new InstanceContext(this);
				this.client = new ВistributedСalculationClient(context);
				this.client.Open();
			}

			this.SetMessage("Start calculate");

			var indata = new CalculationInput() { Start = this.Start, End = this.End };
			CalculationOutput result = await this.client.GetCalculationAsync(indata);
			this.SetResult(result);
		}

		private void SetMessage(string message)
		{
			Action setMessage = () =>
			{
				this.txtResult.AppendText(string.Format("{0} -- {1}{2}", DateTime.Now, message, Environment.NewLine));
			};

			if (this.txtResult.InvokeRequired)
			{
				this.txtResult.Invoke(setMessage);
			}
			else
			{
				setMessage.Invoke();
			}
		}

		#region IВistributedСalculationCallback Members

		public CalculationOutput Calculate(CalculationParameterForUnit input)
		{
			throw new NotImplementedException();
		}

		public bool Ping()
		{
			return true;
		}

		#endregion
	}
}
