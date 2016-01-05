using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
	public class ВistributedСalculation : IВistributedСalculation
	{
		private static List<ICaclculationCallback> _clients = new List<ICaclculationCallback>();

		public CalculationOutput GetCalculation(CalculationInput input)
		{
			int calculationSum = 0;

			int length = (input.End - input.Start) / _clients.Count;

			TestClients();

			for (int i = 0; i < _clients.Count; i++)
			{
				calculationSum += this.AskForCalculations(_clients[i], input.Start + length * i, input.Start + length * (i + 1)).Result;
			}

			var result = new CalculationOutput() { Result = calculationSum };
			return result;
		}

		private void TestClients()
		{
			for (int i = 0; i < _clients.Count; i++)
			{
				try
				{
					_clients[i].Ping();
				}
				catch (ObjectDisposedException)
				{
					_clients.Remove(_clients[i]);
					i--;
				}
				catch (CommunicationException)
				{
					_clients.Remove(_clients[i]);
					i--;
				}
			}
		}

		public bool RememberCalculationUnit()
		{
			ICaclculationCallback unit = OperationContext.Current.GetCallbackChannel<ICaclculationCallback>();
			_clients.Add(unit);
			return true;
		}

		private CalculationOutput AskForCalculations(ICaclculationCallback callback, int start, int end)
		{

			var curInp = new CalculationInput() { Start = start, End = end };
			CalculationOutput r = callback.Calculate(curInp);
			return r;
		}

	}
}
