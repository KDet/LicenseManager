using System;
using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class CustomerViewModel : ReactiveCustomer
	{
        public enum Mode
        {
            View,
            Edit,
            New,
            Export
        }

		private readonly ILicenseManagerRepository _licenseManagerRepository;
        private readonly Mode _mode;

        private RelayCommand _updateCustomerCommand;
        private RelayCommand _editCustomerCommand;
        private RelayCommand _deleteCustomerCommand;

        private readonly Action<ReactiveAttempt> _deleteAction;
	    private readonly Func<ReactiveAttempt, bool> _canDelete;
        private readonly Action<CustomerViewModel> _updateAction;
        private readonly Action<CustomerViewModel> _addNewAction;
        private readonly Action<CustomerViewModel> _addFromAttemptAction;

        public RelayCommand UpdateCustomerCommand
        {
            get
            {
                return _updateCustomerCommand ??
                       (_updateCustomerCommand = new RelayCommand(Done));
            }
        }
	    public RelayCommand EditCustomerCommand
	    {
	        get
	        {
	            return _editCustomerCommand ??
	                   (_editCustomerCommand = new RelayCommand(Edit, () => _mode == Mode.View));
	        }
	    }
	    public RelayCommand DeleteCustomerCommand
	    {
	        get
	        {
	            return _deleteCustomerCommand ??
	                   (_deleteCustomerCommand = new RelayCommand(
	                       () =>
	                       {
	                           if (_deleteAction != null)
	                               _deleteAction(this);
	                       },
	                       () => _canDelete == null || _canDelete(this)));
	        }
	    }


	    private void Done()
	    {
	        var customer = Customer;
            if (_mode == Mode.Edit)
	        {
	            ViewModelLocator.Locator.Customer.Customer = customer;
	            _updateAction(this);
	        }
	        if (_mode == Mode.New)
	        {
	            _addNewAction(this);
	        }
	        if (_mode == Mode.Export)
	        {
	            _addFromAttemptAction(this);
	        }

            NavigatioService.GoBack();
        }
	    private void Edit()
	    {
            ViewModelLocator.Locator.CustomerEdit = new CustomerViewModel(_licenseManagerRepository, Mode.Edit, _deleteAction, _canDelete, _updateAction, _addNewAction, _addFromAttemptAction)
                                                    { Customer = Customer.Clone() };
            NavigatioService.NavigateTo(MessageData.CustomerEditionPageName);
        }

        public CustomerViewModel(ILicenseManagerRepository licenseManagerRepository, Mode mode,
            Action<ReactiveAttempt> deleteAction = null, 
            Func<ReactiveAttempt, bool> canDelete = null,
            Action<CustomerViewModel> updateAction = null,
            Action<CustomerViewModel> addNewAction = null,
            Action<CustomerViewModel> addFromAttemptAction = null)
        {
            _licenseManagerRepository = licenseManagerRepository;
            _mode = mode;

            _deleteAction = deleteAction;
            _canDelete = canDelete;
            _updateAction = updateAction;
            _addNewAction = addNewAction;
            _addFromAttemptAction = addFromAttemptAction;
        }
    }
}