using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService
{
	[DataContract]
	public class CalculationInput
	{
		[DataMember]
		public int Start;

		[DataMember]
		public int End;
	}

	[DataContract]
	public class CalculationOutput
	{
		[DataMember]
		public int Result;
	}
}