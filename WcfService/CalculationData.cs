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
		public long Start;

		[DataMember]
		public long End;
	}

	[DataContract]
	public class CalculationOutput
	{
		[DataMember]
		public long Result;

		[DataMember]
		public string Error { get; set; }

		[DataMember]
		public Exception Exception { get; set; }
	}
}