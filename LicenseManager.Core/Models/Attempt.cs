using System;

namespace LicenseManager.Core.Models
{
    public abstract class ModelBase
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }

    public class Attempt : ModelBase
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

        public Attempt()
        {
            Name = string.Empty;
            CreatedAt = DateTime.Now;
            LastName = string.Empty;
            Position = string.Empty;
            Company = string.Empty;
            Photo = string.Empty;
            PhoneNumber = string.Empty;
            EMail = string.Empty;
            Skype = string.Empty;
            StreetAddress = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            ZipCode = string.Empty;
            AboutUs = string.Empty;
        }

        public Attempt Clone()
        {
            var toReturn = new Attempt();
            Init(toReturn);
            return toReturn;
        }

        protected void Init(Attempt attempt)
        {
            attempt.Id = Id;
            attempt.CreatedAt = CreatedAt;
            attempt.Name = Name;
            attempt.LastName = LastName;
            attempt.Position = Position;
            attempt.Company = Company;
            attempt.Photo = Photo;
            attempt.PhoneNumber = PhoneNumber;
            attempt.EMail = EMail;
            attempt.Skype = Skype;
            attempt.StreetAddress = StreetAddress;
            attempt.City = City;
            attempt.State = State;
            attempt.Country = Country;
            attempt.ZipCode = ZipCode;
            attempt.Latitude = Latitude;
            attempt.Longitude = Longitude;
            attempt.AboutUs = AboutUs;
        } 
    }
}
