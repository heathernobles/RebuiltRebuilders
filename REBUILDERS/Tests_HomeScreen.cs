using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Rebuilder;

namespace Rebuilders.Pages
{
    [TestFixture(Platform.Android)]
                                                      [TestFixture(Platform.iOS)]
    public class Tests_Home
    {
        public Platform platform;
        public HomeScreen homeScreen;
        public SearchResultsScreen searchResults;
        string path;

        public Tests_Home(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            {
                path = "../../com.lkqcorp.rebuilders.qc.apk";
                Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

                homeScreen = new HomeScreen(Settings.AppContext);
                searchResults = new SearchResultsScreen(Settings.AppContext);
            }
        }

        [Test]
        [Category("HomeScreen")]
        public void InitialLoad_FirstHome()
        {
            homeScreen.InitialLoad_FirstInstalled();
        }

       /* [Test]
        [Category("HomeScreen"), Category("Hardcoded"), 
            Category("TC 94368"), Category("TSK 93215")]
        public void SelectPreferredLocationSmoke()
        {
            homeScreen.SelectLocation("LKQ Dominion");
            homeScreen.SelectLocation("LKQ London");
        }

        [Test]
        [Category("HomeScreen"), Category("Hardcoded")]
        public void SetPreferredLocationDominion()
        {
            homeScreen.SelectLocation("LKQ Dominion");
            homeScreen.SetPreferredLocation();
            //searchResults.VerifyLocationResults();
        }


        [Test]
        [Category("HomeScreen"), Category("Hardcoded"), Category("Startup")]
        public void SetPreferredLocationLondon()
        {
            homeScreen.SelectLocation("LKQ London");
            homeScreen.SetPreferredLocation();
            searchResults.VerifyLocationResults();
        }

        [Test]
        [Category("LocationsScreen"), Category("Hardcoded")]
        public void InitialLoad_London()
        {
            SetPreferredLocationLondon();
            app = ConfigureApp
                   .Android
                   .EnableLocalScreenshots()
                   .ApkFile(path)
                   .StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);
            searchResults.VerifyLocationResults();
        }

        [Test]
        [Category("LocationsScreen"), Category("Hardcoded")]
        public void InitialLoad_Dominion()
        {
            SetPreferredLocationDominion();
            app = ConfigureApp
                   .Android
                   .EnableLocalScreenshots()
                   .ApkFile(path)
                   .StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);
            searchResults.VerifyLocationResults();
        }*/
    }
}