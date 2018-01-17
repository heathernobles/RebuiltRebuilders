using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Android;
using System;
using Rebuilder;

namespace Rebuilders.Pages
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests_VehicleDetails
    {
        private Platform platform;
        public HomeScreen homeScreen;
        public SearchResultsScreen searchResults;
        public SettingsScreen settings;
        public Drawer drawer;
        public SavedSearchesScreen savedSearchesScreen;
        public PickerDialog pickerDialog;
        public VehicleDetailsScreen details;

        [SetUp]
        public void BeforeEachTest()
        {
            {
                string path = "../../com.lkqcorp.rebuilders.qc.apk";
                Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp();

                homeScreen = new HomeScreen(Settings.AppContext);
                details = new VehicleDetailsScreen(Settings.AppContext);
                searchResults = new SearchResultsScreen(Settings.AppContext);
                homeScreen.SelectLocation("LKQ London");
                //homeScreen.SetPreferredLocation();
                searchResults.SelectVehicle();
            }
        }

           public Tests_VehicleDetails(Platform platform)
                {
                    this.platform = platform;
                }

        [Test]
        [Category("VehicleDetails")]
        public void InitialLoad_VehicleDetailsScreen()
        {
            details.InitialLoadVehicleDetails();
            Settings.AppContext.Screenshot(details.ToString());
        }

        [Test]
        [Category("VehicleDetails")]
        public void VerifyCallSales()
        {
            details.CallSales();
        }

        [Test]
        [Category("VehicleDetails")]
        public void VerifyEmailSales()
        {
            details.EmailSales();
        }

        [Test]
        [Category("VehicleDetails")]
        public void VerifyLocationMap()
        {
            details.OpenLocation();
        }
    }
        }
