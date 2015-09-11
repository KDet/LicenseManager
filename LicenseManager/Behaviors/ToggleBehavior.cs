using System;
using Xamarin.Forms;

namespace LicenseManager.XamForms.UI.Behaviors
{
    public class ToggleBehavior : Behavior<View>
    {
        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create<ToggleBehavior, bool>(tb => tb.IsToggled, false);

        private TapGestureRecognizer _tapRecognizer;

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool) GetValue(IsToggledProperty); }
        }

        private void OnTapped(object sender, EventArgs args)
        {
            IsToggled = !IsToggled;
        }

        protected override void OnAttachedTo(View view)
        {
            base.OnAttachedTo(view);
            _tapRecognizer = new TapGestureRecognizer();
            _tapRecognizer.Tapped += OnTapped;
            view.GestureRecognizers.Add(_tapRecognizer);
        }
        protected override void OnDetachingFrom(View view)
        {
            base.OnDetachingFrom(view);
            view.GestureRecognizers.Remove(_tapRecognizer);
            _tapRecognizer.Tapped -= OnTapped;
        }
    }
}