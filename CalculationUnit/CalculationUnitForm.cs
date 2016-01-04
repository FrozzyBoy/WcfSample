using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationUnit
{
	public partial class CalculationUnitForm : Form, CalculationService.IВistributedСalculationCallback
	{
		private CalculationService.ВistributedСalculationClient client = null;

		public CalculationUnitForm()
		{
			InitializeComponent();
			var context = new InstanceContext(this);
			this.client = new CalculationService.ВistributedСalculationClient(context);
			this.client.Open();
			this.Disposed += CalculationUnitForm_Disposed;
		}

		private void CalculationUnitForm_Disposed(object sender, EventArgs e)
		{
			this.client.Close();
		}

		private void btnRememberMe_Click(object sender, EventArgs e)
		{
				bool result = this.client.RememberCalculationUnit();
				RememberResult(result);
		}

		private void RememberResult(bool result)
		{
			this.txtLog.Text += string.Format("{0} -- {1}{2}", DateTime.Now, result ? "Was remembered" : "Was fail", Environment.NewLine);
		}

		#region IВistributedСalculationCallback Members

		public CalculationService.CalculationOutput Calculate(CalculationService.CalculationInput input)
		{

			var res = new CalculationService.CalculationOutput() { Result = F(input.Start, input.End) };

			this.txtLog.Text += string.Format(@"{0} -- log {1}
start:{2}{1}
end:{3}{1}
result:{4}{1}
--------------------------------", DateTime.Now, Environment.NewLine, input.Start, input.End, res.Result);

			return res;
		}

		private int F(int st, int end)
		{
			int result = 0;
			for (int i = st; i <= end; i++)
			{
				result += i * i;
			}
			return result;
		}

		#endregion
	}
}
