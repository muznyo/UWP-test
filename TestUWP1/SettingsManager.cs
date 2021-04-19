using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace TestUWP1
{
    public static class SettingsManager
    {
        // Load the app's settings
        public static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public delegate void AppThemeChangedHandler(ElementTheme value);
        public static event AppThemeChangedHandler AppThemeChanged;

        public delegate void SettingsChangedHandler(string name, object value);
        public static event SettingsChangedHandler SettingsChanged;


        private static ElementTheme ThemeFromName(string themeName)
        {
            switch (themeName)
            {
                case "Light":
                    return ElementTheme.Light;

                case "Dark":
                    return ElementTheme.Dark;

                default:
                    return ElementTheme.Default;
            }
        }

        public static ElementTheme GetAppTheme()
        {
            return ThemeFromName(localSettings.Values["AppTheme"] as string);
        }
        public static string GetAppThemeName()
        {
            var theme = localSettings.Values["AppTheme"] as string;
                return theme;
        }
        public static void SetAppTheme(string themeString)
        {
            SetAppTheme(ThemeFromName(themeString));
        }

        public static void SetAppTheme(ElementTheme theme)
        {
            localSettings.Values["AppTheme"] = theme.ToString();
            ApplyAppTheme(theme);
            AppThemeChanged?.Invoke(theme);
            SettingsChanged?.Invoke("AppTheme", theme);
        }
        public static void ApplyAppTheme(ElementTheme theme)
        {
            // Set theme for window root.
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = theme;
            }
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.BackgroundColor = Colors.Transparent;

            switch (theme)
            {
                case ElementTheme.Default:
                    titleBar.ButtonHoverBackgroundColor = (Color)Application.Current.Resources["SystemBaseLowColor"];
                    titleBar.ButtonForegroundColor = (Color)Application.Current.Resources["SystemBaseHighColor"];
                    break;

                case ElementTheme.Light:
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(51, 0, 0, 0);
                    titleBar.ButtonForegroundColor = Colors.Black;
                    break;

                case ElementTheme.Dark:
                    titleBar.ButtonHoverBackgroundColor = Color.FromArgb(51, 255, 255, 255);
                    titleBar.ButtonForegroundColor = Colors.White;
                    break;
            }
        }
        
    }
}