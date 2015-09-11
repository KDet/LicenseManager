namespace LicenseManager.Core.Services
{
	public class MessageData
	{
	    public const string MainPageName = "MainPage";
	    public const string CustomerListPageName = "CustomerListPage";
	    public const string CustomerInfoPageName = "CustomerInfoPage";
	    public const string CustomerEditionPageName = "CustomerEditionPage";


        public const string AttemptListPageName = "AttemptListPage";
        public const string AttemptInfoPageName = "AttemptInfoPage";
        public const string AttemptEditionPageName = "AttemptEditionPage";

        public bool UpdateRequired { get; set; }
        public bool SortRequired { get; set; }

        public MessageData(bool updateRequired = false, bool sortRequired = false)
        {
            UpdateRequired = updateRequired;
            SortRequired = sortRequired;
        }
	}
}