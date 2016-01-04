using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
	[ServiceContract(
		SessionMode = SessionMode.Required,
		CallbackContract = typeof(ICaclculationCallback))]
	public interface IВistributedСalculation
	{
		[OperationContract]
		bool RememberCalculationUnit();

		[OperationContract]
		CalculationOutput GetCalculation(CalculationInput input);
	}
}
