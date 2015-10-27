using Microsoft.WindowsAzure.Mobile.Service;

namespace LicenseManager.Backend.DataObjects
{
    public class Customer : EntityData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Skype { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string AboutUs { get; set; }

        public bool IsClient { get; set; }
        public string Key { get; set; }
    }
}