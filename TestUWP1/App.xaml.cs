using TestUWP1;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TestUWP1
{
    /// <summary>
    /// Poskytuje chování specifické pro aplikaci, které doplňuje výchozí třídu Application.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Inicializuje objekt aplikace typu singleton. Jedná se o první řádek spuštěného vytvořeného kódu,
        /// který je proto logickým ekvivalentem metod main() nebo WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            // Get theme choice from LocalSettings.
            object value = ApplicationData.Current.LocalSettings.Values["themeSetting"];

            if (value != null)
            {
                // Apply theme choice.
                App.Current.RequestedTheme = (ApplicationTheme)(int)value;
            }
        }

        /// <summary>
        /// Vyvolá se při normálním spuštění aplikace koncovým uživatelem. Ostatní vstupní body
        /// se použijí například při spuštění aplikace za účelem otevření konkrétního souboru.
        /// </summary>
        /// <param name="e">Podrobnosti o žádosti o spuštění a procesu</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Neopakovat inicializaci aplikace, pokud už má okno obsah,
            // jenom ověřit, jestli je toto okno aktivní
            if (!(Window.Current.Content is Frame rootFrame))
            {
                // Vytvořit objekt Frame, který bude fungovat jako kontext navigace, a spustit procházení první stránky
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Načíst stav z dříve pozastavené aplikace
                }

                // Umístit rámec do aktuálního objektu Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Pokud není navigační zásobník obnovený, přejít na první stránku
                    // a nakonfigurovat novou stránku předáním požadovaných informací ve formě
                    // parametru navigace
                    rootFrame.Navigate(typeof(Views.NavPage), e.Arguments);
                }
                // Zkontrolovat, jestli je aktuální okno aktivní
                Window.Current.Activate();
            }
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            SettingsManager.ApplyAppTheme(SettingsManager.GetAppTheme());
        }

        /// <summary>
        /// Vyvolá se, když selže přechod na určitou stránku.
        /// </summary>
        /// <param name="sender">Objekt Frame, u kterého selhala navigace</param>
        /// <param name="e">Podrobnosti o chybě navigace</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Vyvolá se při pozastavení běhu aplikace. Stav aplikace se uloží, i když
        /// bez informace, jestli se aplikace ukončí nebo obnoví s obsahem
        /// obsahem paměti.
        /// </summary>
        /// <param name="sender">Zdroj žádosti o pozastavení</param>
        /// <param name="e">Podrobnosti žádosti o pozastavení</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Uložit stav aplikace a zastavit jakoukoliv aktivitu na pozadí
            deferral.Complete();
        }
    }
}
