using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Views;

namespace LicenseManager.WinDesktop.Services
{
    public class WpfNavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationService _navigation;

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentSource == null)
                        return null;
                    var pageType = _navigation.CurrentSource.GetType();
                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public void GoBack()
        {
            _navigation.GoBack();
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }
        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());
                        parameters = new object[]{ };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });
                        parameters = new[] { parameter };
                    }

                    if (constructor == null)
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);

                    var page = constructor.Invoke(parameters) as Page;
                    _navigation.Navigate(page);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format("No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey), "pageKey");
                }
            }
        }
        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
                if (_pagesByKey.ContainsKey(pageKey))
                    _pagesByKey[pageKey] = pageType;
                else
                    _pagesByKey.Add(pageKey, pageType);
        }

        public void Initialize(NavigationService navigation)
        {
            _navigation = navigation;
        }
    }
}
