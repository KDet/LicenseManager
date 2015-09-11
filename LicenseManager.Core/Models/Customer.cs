namespace LicenseManager.Core.Models
{
	public class Customer : Attempt
	{
        public bool IsClient { get; set; }
        public string Key { get; set; }

        public Customer()
	    {
	        IsClient = false;
	        Key = string.Empty;
	    }

	    public new Customer Clone()
	    {
	        var toReturn = new Customer();
            Init(toReturn);
	        return toReturn;
	    }

	    protected void Init(Customer customer)
	    {
	        base.Init(customer);
	        customer.Key = Key;
	        customer.IsClient = IsClient;
	    }
	}
}