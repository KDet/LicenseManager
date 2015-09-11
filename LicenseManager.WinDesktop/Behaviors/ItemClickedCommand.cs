using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LicenseManager.WinDesktop.Behaviors
{
    public static class ItemClickCommandBehavior
    {
        #region Command Attached Property

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof (ICommand), typeof (ItemClickCommandBehavior),
                new PropertyMetadata(null, OnCommandChanged));

        #endregion

        #region Behavior implementation

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lvb = d as ListBox;
            if (lvb != null)
                lvb.PreviewMouseDown += OnPreviewMouseDown;
        }
        private static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var lvb = (ListBox)sender;
            var item = ItemsControl.ContainerFromElement(lvb, (DependencyObject)e.OriginalSource) as ListBoxItem;
            if (item != null)
            {
                var valueItem = FirstOrDefault(item.DataContext as IEnumerable) ?? item.DataContext;
                
                

                var cmd = lvb.GetValue(CommandProperty) as ICommand;
                if (cmd != null && cmd.CanExecute(valueItem))
                    cmd.Execute(valueItem);
            }
        }

        #endregion

        private static object FirstOrDefault(IEnumerable source)
        {
            if (source == null)
                return null;
            var list = source as IList;
            if (list != null)
            {
                if (list.Count > 0)
                    return list[0];
            }
            else
            {
                IEnumerator enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return enumerator.Current;

            }
            return default(object);
        }
    }
}
