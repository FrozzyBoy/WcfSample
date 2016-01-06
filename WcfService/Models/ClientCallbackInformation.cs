namespace WcfService.Models
{
	public class ClientCallbackInformation
	{
		public ICaclculationCallback Client { get; private set; }
		public bool IsEvalable { get; set; }

		public ClientCallbackInformation(ICaclculationCallback client)
		{
			this.Client = client;
			this.IsEvalable = true;
		}

	}
}