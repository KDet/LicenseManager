using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace LicenseManager.Core.Services
{
    public class AzureLicenseManagerRepository : ILicenseManagerRepository
    {
        private readonly MobileServiceClient _mobileService;

        public AzureLicenseManagerRepository()
        {
             _mobileService = new MobileServiceClient("http://localhost:62421/");
            // Use this constructor instead after publishing to the cloud
            //_mobileService = new MobileServiceClient(
            //      "https://licensemanager.azure-mobile.net/",
            //      "HMgDXTgimDGkxhLsrXqOylajsCpKVd37"
            //);
    }

        public async Task<IEnumerable<Attempt>> GetAttemptsAsync()
        {
            var res = await _mobileService.GetTable<Attempt>().ReadAsync();
            return res;
        }
        public Task AddAttemptAsync(Attempt customer)
        {
            return _mobileService.GetTable<Attempt>().InsertAsync(customer);
        }
        public Task RemoveAttemptAsync(Attempt customer)
        {
            return _mobileService.GetTable<Attempt>().DeleteAsync(customer);
        }
        public Task UpdateAttemptAsync(Attempt customer)
        {
            return _mobileService.GetTable<Attempt>().UpdateAsync(customer);
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return _mobileService.GetTable<Customer>().ReadAsync();
        }
        public Task AddCustomerAsync(Customer customer)
        {
            return _mobileService.GetTable<Customer>().InsertAsync(customer);
        }
        public Task RemoveCustomerAsync(Customer customer)
        {
            return _mobileService.GetTable<Customer>().DeleteAsync(customer);
        }
        public Task UpdateCustomerAsync(Customer customer)
        {
            return _mobileService.GetTable<Customer>().UpdateAsync(customer);
        }
    }
}