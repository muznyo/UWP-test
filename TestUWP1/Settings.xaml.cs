using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestUWP1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void Light_Checked(object sender, RoutedEventArgs e)
        {
            ((RadioButton)sender).IsChecked = App.Current.RequestedTheme == ApplicationTheme.Light;
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = ((RadioButton)sender)?.Tag?.ToString();
        }

        private void Dark_Checked(object sender, RoutedEventArgs e)
        {
            ((RadioButton)sender).IsChecked = App.Current.RequestedTheme == ApplicationTheme.Dark;
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = ((RadioButton)sender)?.Tag?.ToString();

        }


        private async void restartButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");

            if (result == AppRestartFailureReason.NotInForeground ||
                result == AppRestartFailureReason.RestartPending ||
                result == AppRestartFailureReason.Other)
            {
                var msgBox = new MessageDialog("Restart Failed", result.ToString());
                await msgBox.ShowAsync();
            }

        }

        private async void Theme_RB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var result = await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");

            if (result == AppRestartFailureReason.NotInForeground ||
                result == AppRestartFailureReason.RestartPending ||
                result == AppRestartFailureReason.Other)
            {
                var msgBox = new MessageDialog("Restart Failed", result.ToString());
                await msgBox.ShowAsync();
            }


        }
    }
}
