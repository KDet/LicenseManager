using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LicenseManager.Core.Helpers;
using LicenseManager.Core.Services;

namespace LicenseManager.Core.ViewModels
{
    public class CustomerListViewModel : BaseListViewModel<CustomerViewModel>
    {
        private readonly INotificationService _notificationService;
        private RelayCommand _newItemCommand;

        private CustomerViewModel CustomerFactory(CustomerViewModel.Mode mode)
        {
            return new CustomerViewModel(LicenseManagerRepository, mode,
                async customer => await Delete(customer as CustomerViewModel),
                reactiveCustomer => !IsBusy,
                async model => await Update(model),
                async model => await AddNew(model), null);
        }
        private void NewItem()
        {
            ViewModelLocator.Locator.CustomerEdit = CustomerFactory(CustomerViewModel.Mode.New);
            NavigatioService.NavigateTo(MessageData.CustomerEditionPageName);
        }
        private void Sort(IEnumerable<CustomerViewModel> items)
        {
            var sorted = from customer in items
                         orderby customer.FullName, customer.IsClient
                         select customer;
            Items = new ObservableCollection<CustomerViewModel>(sorted);

            var grouped = from customer in Items
                          group customer by customer.Date.Date.ToString("d")
                          into sustomerGroup
                          select new Grouping<string, CustomerViewModel>(sustomerGroup.Key, sustomerGroup);

            ItemsGrouped = new ObservableCollection<Grouping<string, CustomerViewModel>>(grouped);
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
                var models = await LicenseManagerRepository.GetCustomersAsync();
			    var items = models.Select(customer =>
			    {
			        var toReturn = CustomerFactory(CustomerViewModel.Mode.View);
			        toReturn.Customer = customer;
			        return toReturn;
			    });
			    Sort(items);
			}
			catch (Exception)
			{
				_notificationService.DisplayAlert("error");
			}
			finally
			{
				IsBusy = false;
				GetItemsCommand.RaiseCanExecuteChanged();
			}
		}
        protected override void GoToItem(CustomerViewModel itemViewModel)
        {
            ViewModelLocator.Locator.Customer = itemViewModel;
            NavigatioService.NavigateTo(MessageData.CustomerInfoPageName);
        }

        public RelayCommand NewItemCommand
        {
            get
            {
                return _newItemCommand ??
                       (_newItemCommand = new RelayCommand(NewItem));
            }
        }

        public CustomerListViewModel(ILicenseManagerRepository licenseManagerRepository, INotificationService notificationService): base(licenseManagerRepository)
        {
            _notificationService = notificationService;
            // GetItems();
            Messenger.Default.Register<MessageData>(this, MessageData.CustomerListPageName, false, async data =>
            {
                if (data.UpdateRequired)
                    await GetItems();
                else
                {
                    if(data.SortRequired)
                        Sort();
                }
            });
            Messenger.Default.Send(new MessageData {UpdateRequired = true}, MessageData.CustomerListPageName);
        }

        public override async Task Delete(CustomerViewModel itemViewModel)
        {
            if (IsBusy || itemViewModel == null)
                return;
            IsBusy = true;
            try
            {
                await LicenseManagerRepository.RemoveCustomerAsync(itemViewModel.Customer);
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
        public async Task Update(CustomerViewModel customerViewModel)
        {
            if (IsBusy || customerViewModel == null)
                return;
            IsBusy = true;
            try
            {
                await LicenseManagerRepository.UpdateCustomerAsync(customerViewModel.Customer);
                Sort();
            }
            catch (Exception)
            {
                _notificationService.DisplayAlert("Unable to update customer, please try again");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task AddNew(CustomerViewModel customerViewModel)
        {
            if (IsBusy || customerViewModel == null)
                return;
            IsBusy = true;
            try
            {
                await LicenseManagerRepository.AddCustomerAsync(customerViewModel.Customer);
                Items.Add(customerViewModel);
                Sort();
            }
            catch (Exception)
            {
                _notificationService.DisplayAlert("Unable to add new customer, please try again");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}