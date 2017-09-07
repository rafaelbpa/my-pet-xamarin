using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MyPet.Models;
using MyPet.Services;
using Newtonsoft.Json;

namespace MyPet.Services
{
    public class PetServices
	{
		AzureDataServices api;
        public IMobileServiceTable<pet> petsTable;

		public async Task<ObservableCollection<pet>> GetPetsAsync()
		{
			api = new AzureDataServices();
            petsTable = api.MobileService.GetTable<pet>();
            IEnumerable<pet> pets = await petsTable.ToEnumerableAsync();

			return new ObservableCollection<pet>(pets);
		}

	}
}
