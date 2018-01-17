using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Android;

namespace Rebuilders.Pages
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests_Settings
    {
        [SetUp]
        public void BeforeEachTest()
        {
            {
                path = "../../com.lkqcorp.rebuilders.qc.apk";
                Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp(AppDataMode.DoNotClear);

                homeScreen = new HomeScreen(Settings.AppContext);
                searchResults = new SearchResultsScreen(Settings.AppContext);
                settings = new SettingsScreen(Settings.AppContext);
                drawer = new Drawer(Settings.AppContext);

                _savedSearchesScreen = new SavedSearchesScreen(Settings.AppContext);
                _pickerDialog = new PickerDialog(Settings.AppContext);

                if (homeScreen.IsLocationSet() == false)
                {
                    homeScreen.SelectLocation("LKQ London");
                }
            }
        }

        private Platform platform;
        public HomeScreen homeScreen;
        public SearchResultsScreen searchResults;
        public SettingsScreen settings;
        public Drawer drawer;
        private string path;
        private SavedSearchesScreen _savedSearchesScreen;
        private PickerDialog _pickerDialog;

        public Tests_Settings(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        [Category("SettingsScreen")]
        public void InitialLoad_Settings()
        {
            drawer.OpenDrawer();
            drawer.TapSettings();
            settings.InitialLoadSettings();
        }

        [Test]
        [Category("SettingsScreen")]
        public void Set_DefaultSearch()//WhenSelectingDefaultSearch_ThenDisplaysListOfSavedSearches
        //When selecting the default search, a list of Saved Searches is displayed
        {
            drawer.NavigateTo("Saved Searches");

            //Get list of saved searches.
            _savedSearchesScreen.WaitToAppear();
            var savedSearches = _savedSearchesScreen.GetItemLabels().Select(x => x.Text).ToArray();
            if (savedSearches.Length == 0) Assert.Inconclusive("Cannot run test. Please create a saved search first.");

            drawer.NavigateTo("Settings");
            Settings.AppContext.Tap(settings.pkDefaultSearchQuery);
            var availableDefaultSearches = _pickerDialog.GetItems().Select(x => x.Text).ToArray();
            Assert.AreNotEqual(0, availableDefaultSearches.Length);
            Assert.AreEqual("None", availableDefaultSearches[0]);
            Assert.AreEqual(savedSearches.Length, availableDefaultSearches.Length - 1);
        }
    }
}