using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using LicenseManager.Core.Services;
using LicenseManager.Core.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace LicenseManager.Core
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get { return _locator ?? (_locator = new ViewModelLocator()); }
        }

#if DEBUG
        private const bool IsInDesign = true;
#else
        public const bool IsInDesign = false;
#endif
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic || IsInDesign)
            {
              // SimpleIoc.Default.Register<ILicenseManagerRepository, AzureLicenseManagerRepository>();
            }
            else
            {
                // Create run time view services and models
               // SimpleIoc.Default.Register<ILicenseManagerRepository, TestLicenseManagerRepository>();
            }

            SimpleIoc.Default.Register(() => new MainViewModel(), false);
            SimpleIoc.Default.Register<CustomerListViewModel>();
            SimpleIoc.Default.Register<AttemptListViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        //        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //            "CA1822:MarkMembersAsStatic",
        //            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
        public CustomerListViewModel CustomerList
        {
            get { return ServiceLocator.Current.GetInstance<CustomerListViewModel>(); }
        }
        public AttemptListViewModel AttemptList
        {
            get { return ServiceLocator.Current.GetInstance<AttemptListViewModel>(); }
        }
        public CustomerViewModel Customer { get; set; }
        public CustomerViewModel CustomerEdit { get; set; }

        public AttemptViewModel Attempt { get; set; }
        public AttemptViewModel AttemptEdit { get; set; }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}