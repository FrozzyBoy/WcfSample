using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
	public interface ICaclculationCallback
	{
		[OperationContract]
		CalculationOutput Calculate(CalculationParameterForUnit input);
		[OperationContract]
		bool Ping();
	}
}
