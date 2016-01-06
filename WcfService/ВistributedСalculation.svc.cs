using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
	public class ВistributedСalculation : IВistributedСalculation
	{
		private static List<ICaclculationCallback> _clients = new List<ICaclculationCallback>();

		public CalculationOutput GetCalculation(CalculationInput input)
		{
			TestClients();

			int calculationSum = 0;

			int length = (input.End - input.Start) / _clients.Count;

			for (int i = 0; i < _clients.Count; i++)
			{
				int segmentStart = input.Start + length * i;
				int segmentEnd = input.Start + length * (i + 1);
				calculationSum += this.AskForCalculations(_clients[i], segmentStart, segmentEnd).Result;
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
					if (!_clients[i].Ping())
					{
						_clients.Remove(_clients[i]);
						i--;
					}
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
