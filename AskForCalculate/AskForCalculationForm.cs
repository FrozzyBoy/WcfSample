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

namespace AskForCalculate
{
	public partial class AskForCalculationForm : Form, CalculationService.IВistributedСalculationCallback
	{
		private CalculationService.ВistributedСalculationClient client = null;

		private int Start
		{
			get
			{
				return ParseInt(this.txtStart.Text);
			}
		}

		private int End
		{
			get
			{
				return ParseInt(this.txtEnd.Text);
			}
		}

		private void SetResult(string result)
		{
			this.txtResult.Text += string.Format("{0} -- The result is of calculation is: {1}{2}", DateTime.Now, result, Environment.NewLine);
		}

		private int ParseInt(string str)
		{
			int result;
			int.TryParse(str, out result);
			return result;
		}

		public AskForCalculationForm()
		{
			InitializeComponent();
			var context = new InstanceContext(this);
			this.client = new CalculationService.ВistributedСalculationClient(context);
			this.client.Open();
			this.Disposed += AskForCalculationForm_Disposed;

		}

		private void AskForCalculationForm_Disposed(object sender, EventArgs e)
		{
			this.client.Close();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			var indata = new CalculationService.CalculationInput() { Start = this.Start, End = this.End };
			var result = this.client.GetCalculation(indata);
			this.SetResult(result.Result.ToString());
		}

		#region IВistributedСalculationCallback Members

		public CalculationService.CalculationOutput Calculate(CalculationService.CalculationInput input)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
