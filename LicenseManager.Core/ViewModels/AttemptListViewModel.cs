using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using LicenseManager.Core.Helpers;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class AttemptListViewModel : BaseListViewModel<AttemptViewModel>
    {
        private readonly INotificationService _notificationService;
        private RelayCommand<AttemptViewModel> _saveAsCustomerCommand;

        private void SaveAsCustomer(AttemptViewModel itemViewModel)
        {
            ViewModelLocator.Locator.CustomerEdit = new CustomerViewModel(LicenseManagerRepository, CustomerViewModel.Mode.Export, null, null, null, null,
                async customerViewModel =>
                {
                    var customerListViewModel = ViewModelLocator.Locator.CustomerList;
                    await customerListViewModel.AddNew(customerViewModel);
                    await Delete(itemViewModel);
                })
            { Attempt = itemViewModel.Attempt.Clone() };
            NavigatioService.NavigateTo(MessageData.CustomerEditionPageName);
        }
        private void Sort(IEnumerable<AttemptViewModel> items)
        {
            var sorted = from attempt in items
                         orderby attempt.Date descending, attempt.FullName
                         select attempt;
            Items = new ObservableCollection<AttemptViewModel>(sorted);

            var grouped = from attempt in Items
                          group attempt by attempt.Date.ToString("d")
                          into sustomerGroup
                          select new Grouping<string, AttemptViewModel>(sustomerGroup.Key, sustomerGroup);

            ItemsGrouped = new ObservableCollection<Grouping<string, AttemptViewModel>>(grouped);
        }
        private void Sort()
        {
            Sort(Items);
        }

        protected override async Task GetItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetItemsCommand.RaiseCanExecuteChanged();
            try
            {
                var models = await LicenseManagerRepository.GetAttemptsAsync();
                var items = models.Select(attempt =>
                {
                    return new AttemptViewModel(LicenseManagerRepository,
                        async attemptViewModel => await Delete(attemptViewModel as AttemptViewModel),
                        attemptViewModel => !IsBusy, SaveAsCustomer)
                    {Attempt = attempt};
                });
                Sort(items);
            }
            catch (Exception)
            {
                _notificationService.DisplayAlert("Unable to fetch customer, please try again");
            }
            finally
            {
                IsBusy = false;
                GetItemsCommand.RaiseCanExecuteChanged();
            }
        }
        protected override void GoToItem(AttemptViewModel itemViewModel)
        {
            ViewModelLocator.Locator.Attempt = itemViewModel;
            NavigatioService.NavigateTo(MessageData.AttemptInfoPageName);
        }

        public RelayCommand<AttemptViewModel> SaveAsCustomerCommand
        {
            get
            {
                return _saveAsCustomerCommand ??
                       (_saveAsCustomerCommand = new RelayCommand<AttemptViewModel>(SaveAsCustomer));
            }
        }

        public AttemptListViewModel(ILicenseManagerRepository licenseManagerRepository, INotificationService notificationService): base(licenseManagerRepository)
        {
            _notificationService = notificationService;
            GetItems();
        }

        public override async Task Delete(AttemptViewModel itemViewModel)
        {
            if (IsBusy || itemViewModel == null)
                return;
            IsBusy = true;
            try
            {
                await LicenseManagerRepository.RemoveAttemptAsync(itemViewModel.Attempt);
                Items.Remove(itemViewModel);
                Sort();
            }
            catch (Exception)
            {
                _notificationService.DisplayAlert("Unable to remove customer, please try again");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}