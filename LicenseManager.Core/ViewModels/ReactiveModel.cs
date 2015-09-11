using System;
using LicenseManager.Core.Models;

namespace LicenseManager.Core.ViewModels
{
    public abstract class ReactiveAttempt : BaseViewModel
    {
        private const string DefaultPhotoUri = "http://www.iconpng.com/png/desktop-icons/company.png";

        protected Attempt _model;

        private DateTime _date = DateTime.Now;
        private string _name = string.Empty;
        private string _lastName = string.Empty;
        private string _position = string.Empty;
        private string _company = string.Empty;
        private string _photo = DefaultPhotoUri;
        private string _phoneNumber = string.Empty;
        private string _eMail = string.Empty;
        private string _skype = string.Empty;
        private string _streetAddress = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _country = string.Empty;
        private string _zipCode = string.Empty;
        private double _latitude;
        private double _longitude;
        private string _aboutUs = string.Empty;

        public Attempt Attempt
        {
            get { return InitModel(_model); }
            set
            {
                _model = value;
                InitViewModel(_model);
            }
        }

        protected ReactiveAttempt()
        {
            _model = new Attempt();
        }

        public DateTime Date
        {
            get { return _date; }
            set { Set(() => Date, ref _date, value); }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (Set(() => Name, ref _name, value))
                    RaisePropertyChanged(() => FullName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (Set(() => LastName, ref _lastName, value))
                    RaisePropertyChanged(() => FullName);
            }
        }
        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, Name); }
        }
        public string Position
        {
            get { return _position; }
            set { Set(() => Position, ref _position, value); }
        }
        public string Company
        {
            get { return _company; }
            set { Set(() => Company, ref _company, value); }
        }
        public string Photo
        {
            get { return _photo; }
            set
            {
                if (Set(() => Photo, ref _photo, value))
                    RaisePropertyChanged(() => PhotoUri);
            }
        }
        public Uri PhotoUri
        {
            get { return new Uri(Photo); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { Set(() => PhoneNumber, ref _phoneNumber, value); }
        }
        public string EMail
        {
            get { return _eMail; }
            set { Set(() => EMail, ref _eMail, value); }
        }
        public string Skype
        {
            get { return _skype; }
            set { Set(() => Skype, ref _skype, value); }
        }
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { Set(() => StreetAddress, ref _streetAddress, value); }
        }
        public string City
        {
            get { return _city; }
            set { Set(() => City, ref _city, value); }
        }
        public string State
        {
            get { return _state; }
            set { Set(() => State, ref _state, value); }
        }
        public string Country
        {
            get { return _country; }
            set { Set(() => Country, ref _country, value); }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { Set(() => ZipCode, ref _zipCode, value); }
        }
        public double Latitude
        {
            get { return _latitude; }
            set { Set(() => Latitude, ref _latitude, value); }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { Set(() => Longitude, ref _longitude, value); }
        }
        public string AboutUs
        {
            get { return _aboutUs; }
            set { Set(() => AboutUs, ref _aboutUs, value); }
        }

        protected  void InitViewModel(Attempt model)
        {
            Date = model.CreatedAt.GetValueOrDefault().DateTime;
            Name = model.Name;
            LastName = model.LastName;
            Position = model.Position;
            Company = model.Company;
            Photo = model.Photo;
            PhoneNumber = model.PhoneNumber;
            EMail = model.EMail;
            Skype = model.Skype;
            StreetAddress = model.StreetAddress;
            City = model.City;
            State = model.State;
            Country = model.Country;
            ZipCode = model.ZipCode;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            AboutUs = model.AboutUs;
        }
        protected  Attempt InitModel(Attempt model)
        {
            model.CreatedAt = Date;
            model.Name = Name;
            model.LastName = LastName;
            model.Position = Position;
            model.Company = Company;
            model.Photo = Photo;
            model.PhoneNumber = PhoneNumber;
            model.EMail = EMail;
            model.Skype = Skype;
            model.StreetAddress = StreetAddress;
            model.City = City;
            model.State = State;
            model.Country = Country;
            model.ZipCode = ZipCode;
            model.Latitude = Latitude;
            model.Longitude = Longitude;
            model.AboutUs = AboutUs;
            return model;
        }
    }
    public abstract class ReactiveCustomer: ReactiveAttempt
    {
        private bool _isClient = false;
        private string _key = string.Empty;

        public bool IsClient
        {
            get { return _isClient; }
            set { Set(() => IsClient, ref _isClient, value); }
        }
        public string Key
        {
            get { return _key; }
            set { Set(() => Key, ref _key , value); }
        }

        public Customer Customer
        {
            get { return InitModel(_model); }
            set
            {
                _model = value;
                InitViewModel(_model);
            }
        }

        protected ReactiveCustomer()
        {
            _model = new Customer();
        }

        protected new Customer InitModel(Attempt model)
        {
            var toReturn = model as Customer ?? new Customer();
            base.InitModel(toReturn);
            toReturn.IsClient = IsClient;
            toReturn.Key = Key;
            return toReturn;
        }
        protected new void InitViewModel(Attempt model)
        {
            var customer = model as Customer;
            if (customer != null)
            {
                IsClient = customer.IsClient;
                Key = customer.Key;
            }
            base.InitViewModel(model);
        }
    }
}