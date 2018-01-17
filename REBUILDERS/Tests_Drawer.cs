using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebuilder;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace Rebuilders.Pages
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]

    public class Tests_Drawer
    {

        Platform platform;
        public Drawer drawer;
        public HomeScreen homeScreen;


        public Tests_Drawer(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            string path = "../../com.lkqcorp.rebuilders.qc.apk";
            Settings.AppContext = ConfigureApp
                .Android
                .EnableLocalScreenshots()
                .ApkFile(path)
                .StartApp(AppDataMode.DoNotClear);

            drawer = new Drawer(Settings.AppContext);
            homeScreen = new HomeScreen(Settings.AppContext);
            homeScreen.SelectLocation("LKQ Dominion");
        }

        [Test]
        [Category("Drawer")]
        public void NavigateToSearch()
        {
            SearchScreen search = new SearchScreen(Settings.AppContext);
            drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(search.Page);
            Settings.AppContext.Screenshot("Verify search screen loaded correctly");
        }

        [Test]
        [Category("Drawer")]
        public void NavigateToSettings()
        {
            SettingsScreen settings = new SettingsScreen(Settings.AppContext);
            drawer.NavigateTo("Settings");
            Settings.AppContext.WaitForElement(settings.pkPreferredLocationQuery);
            Settings.AppContext.Screenshot("Verify settings screen loaded correctly");
        }

        [Test]
        [Category("Drawer")]
        public void NavigateToSavedSearches()
        {
            SavedSearchesScreen savedSearches = new SavedSearchesScreen(Settings.AppContext);
            drawer.NavigateTo("Saved Searches");
            savedSearches.WaitToAppear();
            Settings.AppContext.Screenshot("Verify saved searches screen loaded correctly");
        }

        [Test]
        [Category("Drawer")]
        public void NavigateToHome()
        {
            drawer.NavigateTo("Home");
            Settings.AppContext.WaitForElement(c=>c.Marked("btnSavedSearches"));
            Settings.AppContext.Screenshot("Verify home screen loaded correctly");
        }

        [Test]
        [Category("Helper")]
        public void OpenDrawer()
        {
            drawer.OpenDrawer();
        }

        [Test]
        [Category("OrderedTest")]
        public void DrawerTest()
        {
            OpenDrawer();
            NavigateToSearch();
            NavigateToSettings();
            NavigateToHome();
            NavigateToSavedSearches();           
        }
    }
}
