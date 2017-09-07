using Microsoft.WindowsAzure.MobileServices;
using MyPet.Models;
using MyPet.Util;

namespace MyPet.Services
{
    public class AzureDataServices
    {
		public MobileServiceClient MobileService { get; set; }

        public AzureDataServices()
		{
            MobileService = new MobileServiceClient(Constants.API_URL);
		}


    }
}
