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
using Windows.Storage;


// Dokumentaci k šabloně položky Prázdná stránka najdete na adrese https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x405

namespace TestUWP1
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo v rámci objektu Frame
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //TitleBar();


        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            // Save theme choice to LocalSettings. 
            // ApplicationTheme enum values: 0 = Light, 1 = Dark
            ApplicationData.Current.LocalSettings.Values["themeSetting"] =
                                                             ((ToggleSwitch)sender).IsOn ? 0 : 1;
        }

        private void ToggleSwitch_Loaded(object sender, RoutedEventArgs e)
        {
            ((ToggleSwitch)sender).IsOn = App.Current.RequestedTheme == ApplicationTheme.Light;


        }

        //public void TitleBar()
        //{
        //    Window.Current.SetTitleBar(AppTitleBar);
        //    //hiding titlebar
        //    ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
        //    //changing background for minimize, maximize and close buttons
        //    formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
        //    formattableTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        //    formattableTitleBar.BackgroundColor = Colors.Transparent;

        //    var isDark = Application.Current.RequestedTheme == ApplicationTheme.Dark;

        //    if (isDark)
        //    {
        //        formattableTitleBar.ButtonForegroundColor = Colors.White;
        //        formattableTitleBar.ButtonHoverForegroundColor = Colors.White;
        //        formattableTitleBar.ButtonHoverBackgroundColor = Colors.DarkGray;

        //    }
        //    else
        //    {
        //        formattableTitleBar.ButtonForegroundColor = Colors.Black;
        //        formattableTitleBar.ButtonHoverForegroundColor = Colors.Black;
        //        formattableTitleBar.ButtonHoverBackgroundColor = Colors.LightGray;
        //    }

        //}

        //private void NavView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        //{

        //        NavigationViewItem item = args.SelectedItem as NavigationViewItem;
        //        switch (item.Tag.ToString())
        //        {
        //            case "HomeNav":
        //                ContentFrame.Navigate(typeof(Home));
        //                break;
        //            //case "SettingsNav":
        //            //    ContentFrame.Navigate(typeof(MainPage));
        //            //    break;

        //                //case "AppNav"
        //                //case "MusicNav"
        //                //case "UserNav"
        //        }
        //}
        //private void NavView_Loaded(object sender, RoutedEventArgs e)
        //{
        //        ContentFrame.Navigate(typeof(MainPage));
        //}
    }
}
