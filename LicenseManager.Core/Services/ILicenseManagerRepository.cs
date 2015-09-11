using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Models;

namespace LicenseManager.Core.Services
{
	public interface ILicenseManagerRepository
	{
        Task<IEnumerable<Attempt>> GetAttemptsAsync();
        Task AddAttemptAsync(Attempt customer);
        Task RemoveAttemptAsync(Attempt customer);
        Task UpdateAttemptAsync(Attempt customer);

        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
		Task RemoveCustomerAsync(Customer customer);
		Task UpdateCustomerAsync(Customer customer);
	}
}