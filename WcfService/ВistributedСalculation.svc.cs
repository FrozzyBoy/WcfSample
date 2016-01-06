using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WcfService.Models;

namespace WcfService
{
	public class ВistributedСalculation : IВistributedСalculation
	{
		private static List<ClientCallbackInformation> _clients = new List<ClientCallbackInformation>();
		private static object _lockClient = new object();

		private CalculationOutput _result;

		private int _clientIndex = 0;


		public CalculationOutput GetCalculation(CalculationInput input)
		{
			this._result = new CalculationOutput();

			List<CalculationParameterForUnit> source = new List<CalculationParameterForUnit>();

			for (long i = input.Start; i <= input.End; i++)
			{
				source.Add(new CalculationParameterForUnit() { X = i });
			}

			Parallel.ForEach<CalculationParameterForUnit>(source, CalculateOne);

			if (!string.IsNullOrWhiteSpace(_result.Error))
			{
				_result.Result = -1;
			}

			return this._result;
		}

		public bool RememberCalculationUnit()
		{
			ICaclculationCallback unit = OperationContext.Current.GetCallbackChannel<ICaclculationCallback>();
			_clients.Add(new ClientCallbackInformation(unit));
			return true;
		}

		#region Private methods

		private void CalculateOne(CalculationParameterForUnit inputData, ParallelLoopState loopState, long currentIndex)
		{
			ClientCallbackInformation client = null;

			try
			{

				client = this.GetNextClient();

				if (_clients.Count < 1)
				{
					_result.Error = "Все клиенты отключились. Вычисления не закончены.";
				}
				else
				{
					lock (_result)
					{
						this._result.Result += client.Client.Calculate(inputData).Result;
					}
				}
			}
			#region catch exception
			catch (ArgumentNullException ex)
			{
				_result.Exception = ex;
				_result.Error = "Ошибочные данные от клиентов. Вычисления не закончены.";
			}
			catch (ArgumentException ex)
			{
				_result.Exception = ex;
				_result.Error = "Ошибочные данные от клиентов. Вычисления не закончены.";
			}
			catch (Exception ex)
			{
				_result.Exception = ex;
				_result.Error = ex.Message;
			}
			#endregion
			finally
			{
				if (client != null)
				{
					client.IsEvalable = true;
				}

				if (!string.IsNullOrWhiteSpace(_result.Error))
				{
					_result.Error = string.Format("{0}{1}"
						, _result.Error
						, string.Format("{0}Вычисления прервались на {1} элементе.", Environment.NewLine, currentIndex));
					loopState.Break();
				}

			}

		}

		private ClientCallbackInformation GetNextClient()
		{
			ClientCallbackInformation client = null;

			lock (_lockClient)
			{
				while (_clients.Count > 0
					&& client == null)
				{
					if (_clientIndex >= _clients.Count)
					{
						_clientIndex = 0;
					}
					if (_clients[_clientIndex].IsEvalable)
					{
						try
						{
							if (_clients[_clientIndex].Client.Ping())
							{
								client = _clients[_clientIndex];
								_clientIndex++;
								client.IsEvalable = false;
								break;
							}
						}
						#region catch exception
						catch (ObjectDisposedException)
						{
							_clients.Remove(_clients[_clientIndex]);
							_clientIndex--;
						}
						catch (CommunicationException)
						{
							_clients.Remove(_clients[_clientIndex]);
							_clientIndex--;
						}
						#endregion
					}
				}

				return client;
			}
		}
		#endregion

	}
}
