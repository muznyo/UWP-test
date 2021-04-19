using TestUWP1;
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

namespace TestUWP1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            SettingsManager.AppThemeChanged += SettingsManager_AppThemeChanged;
        }


        private void SettingsManager_AppThemeChanged(ElementTheme value)
        {
            ThemeBox.SelectedValue = SettingsManager.GetAppThemeName();
        }
        private void ThemeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingsManager.SetAppTheme(e.AddedItems[0].ToString());
        }

    }
}
