using System;
using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class AttemptViewModel : ReactiveAttempt
    {
        private readonly ILicenseManagerRepository _licenseManagerRepository;

        private RelayCommand _saveAsCustomerCommand;
        private RelayCommand _deleteCustomerCommand;
        private readonly Action<ReactiveAttempt> _deleteAction;
        private readonly Func<ReactiveAttempt, bool> _canDelete;
        private readonly Action<AttemptViewModel> _saveAsCustomerAction;

        public RelayCommand SaveAsCustomerCommand
        {
            get
            {
                return _saveAsCustomerCommand ??
                       (_saveAsCustomerCommand = new RelayCommand(() => _saveAsCustomerAction(this)));
            }
        }
        public RelayCommand DeleteAttemptCommand
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

        public AttemptViewModel(ILicenseManagerRepository licenseManagerRepository, 
            Action<ReactiveAttempt> deleteAction = null, 
            Func<ReactiveAttempt, bool> canDelete = null, 
            Action<AttemptViewModel> saveAsCustomerAction = null)
        {
            _licenseManagerRepository = licenseManagerRepository;
            _deleteAction = deleteAction;
            _canDelete = canDelete;
            _saveAsCustomerAction = saveAsCustomerAction;
        }
    }
}