namespace LicenseManager.Backend.DataObjects
{
    public class Customer : Attempt
    {
        public bool IsClient { get; set; }
        public string Key { get; set; }
    }
}