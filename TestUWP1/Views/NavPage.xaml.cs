using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestUWP1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavPage : Page
    {
        public NavPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(HomePage));
            NavView.Header = "Home";
            NavView.SelectedItem = NavView.MenuItems.ElementAt(0);

        }
        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            string navTo = args.InvokedItemContainer.Tag.ToString();

            if (navTo != null)
            {
                switch (navTo)
                {
                    case "HomeNav":
                        contentFrame.Navigate(typeof(HomePage));
                        NavView.Header = "Home";
                        break;
                    case "SettingsNav":
                        contentFrame.Navigate(typeof(SettingsPage));
                        NavView.Header = "Settings";
                        break;
                }
            }
        }

    }
}
