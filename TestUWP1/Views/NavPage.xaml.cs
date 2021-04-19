using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

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
        //navigating between pages
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

        //disables focus element on startup
        private ScrollViewer GetRootScrollViewer()
        {
            DependencyObject el = this;
            while (el != null && !(el is ScrollViewer))
            {
                el = VisualTreeHelper.GetParent(el);
            }

            return (ScrollViewer)el;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetRootScrollViewer().Focus(FocusState.Programmatic);
        }

    }

    }

