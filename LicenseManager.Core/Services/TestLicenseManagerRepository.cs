using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseManager.Core.Models;

namespace LicenseManager.Core.Services
{
    public class TestLicenseManagerRepository : ILicenseManagerRepository
	{
		#region test data
	    private List<Customer> _customers = new List<Customer>
	    {
            new Customer
            {
                Id = "1",
                CreatedAt = DateTime.Now,
                IsClient = false,
                Key = "67890",
                Name = "Ivan",
                LastName = "Ivanovenkovich",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
	        new Customer
	        {
	            Id = "2",
                CreatedAt = DateTime.Now,
                IsClient = true,
                Key = "12345",
	            Name = "Sarah",
	            LastName = "Connor",
	            Position = "Security Manager",
	            Company = "Xamarin Inc. Argentina",
	            Photo = "http://www.refractored.com/images/SF.png",
	            PhoneNumber = "855-926-2746",
	            EMail = "sarah.connor@mail.com",
	            Skype = "",
	            StreetAddress = "Av. Pres. Roque Saenz Pena 875",
	            City = "Buenos Aires",
	            State = "",
	            Country = "Argentina",
	            ZipCode = "C1035AAD CABA",
	            Latitude = -34.6049956875424,
	            Longitude = -58.3788027544727,
	            AboutUs = "Visual Studio to the Max!"
	        },
            new Customer
            {
                Id = "3",
                CreatedAt = DateTime.Now - TimeSpan.FromDays(1),
                IsClient = true,
                Key = "12345",
                Name = "A",
                LastName = "B",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
        };
        private List<Attempt> _attempts = new List<Attempt>
        {
            new Attempt
            {
                Id = "1",
                Name = "John",
                CreatedAt = DateTime.Now,
                LastName = "Bond",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
            new Attempt
            {
                Id = "2",
                Name = "Sarah",
                CreatedAt = DateTime.Now - TimeSpan.FromDays(2),
                LastName = "R",
                Position = "Security Manager",
                Company = "Terminator Inc. U.S.A.",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-926-2746",
                EMail = "sarah.connor@mail.com",
                Skype = "",
                StreetAddress = "Av. Pres. Roque Saenz Pena 875",
                City = "Buenos Aires",
                State = "",
                Country = "Argentina",
                ZipCode = "C1035AAD CABA",
                Latitude = -34.6049956875424,
                Longitude = -58.3788027544727,
                AboutUs = "Visual Studio to the Max!"
            },
            new Attempt
            {
                Id = "3",
                Name = "Ron",
                CreatedAt = DateTime.Now,
                LastName = "Bon",
                Position = "Software Developer",
                Company = "Xamarin HQ",
                Photo = "http://www.refractored.com/images/SF.png",
                PhoneNumber = "855-916-2743",
                EMail = "ivanov@xam.com",
                Skype = "ivanov.ivan",
                StreetAddress = "394 Pacific Ave. 4th Floor",
                City = "San Francisco",
                State = "CA",
                Country = "United States",
                ZipCode = "94111",
                Latitude = 37.797788,
                Longitude = -122.401858,
                AboutUs = "Sansome & Pacific"
            },
        };


        #endregion
        
	    public async Task<IEnumerable<Attempt>> GetAttemptsAsync()
	    {
            _attempts = new List<Attempt>(_attempts);
            return _attempts;
        }
	    public async Task AddAttemptAsync(Attempt customer)
	    {
	        if (_attempts.Find(attempt => attempt.Id == customer.Id) == null)
	            _attempts.Add(customer);
	    }
	    public async Task RemoveAttemptAsync(Attempt attempt)
	    {
	         _attempts.Remove(attempt);
	    }
	    public async Task UpdateAttemptAsync(Attempt customer)
	    {
            for (int i = 0; i < _attempts.Count; i++)
                if (string.Equals(_attempts[i].Id, customer.Id))
                {
                    _attempts[i] = customer;
                    return ;
                }
        }

	    public async Task<IEnumerable<Customer>> GetCustomersAsync()
		{
			_customers =  new List<Customer>(_customers);
			return  _customers;
		}
	    public async Task AddCustomerAsync(Customer customer)
		{
	        if (_customers.Find(attempt => attempt.Id == customer.Id) == null)
	            _customers.Add(customer);
		}
		public async Task RemoveCustomerAsync(Customer customer)
		{
		    _customers.Remove(customer);
		}
		public async Task UpdateCustomerAsync(Customer customer)
		{
			for (int i = 0; i < _customers.Count; i++)
				if (string.Equals(_customers[i].Id, customer.Id))
				{
					_customers[i] = customer;
				}
		}
	}
}