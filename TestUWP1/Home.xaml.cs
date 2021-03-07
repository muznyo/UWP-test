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
using Microsoft.Toolkit.Uwp;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestUWP1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            TitleBar();



        }
        public void TitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(AppTitleBar);
            //hiding titlebar
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            //changing background for minimize, maximize and close buttons
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            formattableTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            formattableTitleBar.BackgroundColor = Colors.Transparent;

            var isDark = Application.Current.RequestedTheme == ApplicationTheme.Dark;

            if (isDark)
            {
                formattableTitleBar.ButtonForegroundColor = Colors.White;
                formattableTitleBar.ButtonHoverForegroundColor = Colors.White;
                formattableTitleBar.ButtonHoverBackgroundColor = Colors.DarkGray;

            }
            else
            {
                formattableTitleBar.ButtonForegroundColor = Colors.Black;
                formattableTitleBar.ButtonHoverForegroundColor = Colors.Black;
                formattableTitleBar.ButtonHoverBackgroundColor = Colors.LightGray;
            }

        }

        private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(MainPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "HomeNav":
                        ContentFrame.Navigate(typeof(Home));
                        break;
                        //case "AppNav"
                        //case "MusicNav"
                        //case "UserNav"
                }

            }
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Home));
        }
    }
}
