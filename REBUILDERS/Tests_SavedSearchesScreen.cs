using System.Linq;
using NUnit.Framework;
using Rebuilder;
using Rebuilders.Pages;
using Xamarin.UITest;

namespace Rebuilders
{
    [TestFixture(Platform.Android)]
    public class Tests_SavedSearchesScreen
    {
        private readonly Platform _platform;   
        private SavedSearchesScreen _savedSearchesScreen;
        private HomeScreen _homeScreen;
        private Drawer _drawer;
        private LocationsScreen locations;

        public Tests_SavedSearchesScreen(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Settings.AppContext = AppInitializer.StartApp(_platform);
            _savedSearchesScreen = new SavedSearchesScreen(Settings.AppContext);
            _homeScreen = new HomeScreen(Settings.AppContext);
            _drawer = new Drawer(Settings.AppContext);
            locations = new LocationsScreen(Settings.AppContext);
            _homeScreen.SelectLocation("LKQ London");
            //_homeScreen.SetPreferredLocation();

        }

        [Test]
        [Category("SavedSearch")]
        public void a_Verify_Search_Saved()
        {
            _savedSearchesScreen.WhenSaveSearch_ThenSearchSaved(); 
            _savedSearchesScreen.Verify_SavedSearches_ButtonExists(); //TC 84515

        }

        [Test]
        [Category("SavedSearch")]
        public void b_Verify_Tapping_SavedSearch_Shows_Results()
        {
            _savedSearchesScreen.WhenSavedSearchTapped_ThenResultsScreenShown();
        }

        [Test]
        [Category("SavedSearch")]
        public void c_Verify_SavedSearch_Deleted()
        {
            _savedSearchesScreen.WhenSaveSearch_ThenSearchSaved();
            _savedSearchesScreen.Delete_SavedSearch();
        }

        [Test]
        [Category("SavedSearchesSmoke")]
        public void SavedSearches_SmokeTest()
        {
            _savedSearchesScreen.WhenSaveSearch_ThenSearchSaved();
            _savedSearchesScreen.Verify_SavedSearches_ButtonExists();
            _savedSearchesScreen.WhenSavedSearchTapped_ThenResultsScreenShown();
            Settings.AppContext.Back();
            _savedSearchesScreen.Delete_SavedSearch();
            Settings.AppContext.Back();
            _savedSearchesScreen.StartApp_PersistCache();
            Settings.AppContext.Screenshot("Reload");
            _drawer.NavigateTo("Saved Searches");
            _savedSearchesScreen.GetCount(_savedSearchesScreen.ItemLabels);
        }

        [Test]
        [Category("SavedSearch")]
        public void MultiLocation_SavedSearch()
        {
            _savedSearchesScreen.Verify_MultiYard_SavedSearch();
        }
    }
}
