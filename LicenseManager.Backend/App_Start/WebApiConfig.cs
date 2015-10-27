using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using LicenseManager.Backend.DataObjects;
using LicenseManager.Backend.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace LicenseManager.Backend
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new MobileServiceInitializer());
        }
    }
//#if DEBUG
    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
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
            }
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
            }
        };
        #endregion
        protected override void Seed(MobileServiceContext context)
        {
           
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item" }
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            foreach (Attempt attempt in _attempts)
            {
                context.Set<Attempt>().Add(attempt);
            }

            foreach (Customer customer in _customers)
            {
                context.Set<Customer>().Add(customer);
            }

            base.Seed(context);
        }
    }
//#else
//        public class MobileServiceInitializer: ClearDatabaseSchemaIfModelChanges<MobileServiceContext> { }
//#endif

}

