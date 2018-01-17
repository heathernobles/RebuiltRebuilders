using System.Linq;
using NUnit.Framework;
using Rebuilder;
using Rebuilders.Pages;
using Xamarin.UITest;
using System;
using Rebuilders.Utils;

namespace Rebuilders
{
    [TestFixture(Platform.Android)]
    public class Tests_SearchScreen
    {
        private Platform platform;
        private SearchScreen _searchScreen;
        private HomeScreen _homeScreen;

        public Query DoneButton;
        public Query CancelButton;

        public Tests_SearchScreen(Platform platform)
        {
            platform = Platform.Android;
            DoneButton = new Query(c => c.Marked("btnDone"));
            CancelButton = new Query(c => c.Marked("button2"));
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile("../../com.lkqcorp.rebuilders.qc.apk")
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.DoNotClear);

            _searchScreen = new SearchScreen(Settings.AppContext);
            _homeScreen = new HomeScreen(Settings.AppContext);
            if (_homeScreen.IsLocationSet() == false)
            {
                _homeScreen.SelectLocation("LKQ London");
                //_homeScreen.SetPreferredLocation();
            }
        }

        [Test]
        [Category("SearchScreen")]
        public void a_OpenSearchFromDrawer()
        {
            _searchScreen.WhenDrawerSearchItemTapped_ThenSearchPageAppears();
        }

        [Test]
        [Category("SearchScreen")]
        public void b_Verify_Locations_Has_Data()
        {
            _searchScreen.WhenSearchPageLoaded_ThenLocationsHasData();
        }

        [Test]
        [Category("SearchScreen")]
        public void c_Verify_Branding_Has_Data()
        {
            _searchScreen.Verify_Search_BrandsPicker();
        }

        [Test]
        [Category("SearchScreen")]
        public void d_Verify_Years_Has_Data()
        {
            //Validating year from.
            _searchScreen.WhenSearchPageLoaded_ThenYearFromToHasData();
        }

        [Test]
        [Category("SearchScreen")]
        public void h_Verify_Types_Has_Data()
        {
            _searchScreen.WhenSearchPageLoaded_ThenVehicleTypeHasData();
        }

        [Test]
        [Category("SearchScreen")]
        public void f_Verify_Makes_Has_Data()
        {
            _searchScreen.WhenSearchPageLoaded_ThenMakesHasData();
        }

        [Test]
        [Category("SearchScreen")]
        public void g_Verify_Models_Has_Data()
        {
            _searchScreen.WhenSearchPageLoaded_ThenModelsHasData();
        }


        [Test]
        [Category("SearchScreen")]
        public void i_Verify_1950_LessThan_10Makes()
        {
            _searchScreen.WhenSelecting1950_ThenLessThan10MakesAreLoaded();
        }

        [Test]
        [Category("SearchScreen")]
        public void j_Verify_1950_Chevy_LessThan_10Models()
        {
            _searchScreen.Verify_Search_1950_Chevrolet();
        }

        [Test]
        [Category("SearchScreen")]
        public void k_Verify_AllYears_MoreThan_2Makes_AllModels()
        {
            _searchScreen.Verify_Search_AllYearsSelected();
        }

        [Test]
        [Category("SearchScreen")]
        public void l_Verify_Tapping_Search_Shows_Results()
        {
            _searchScreen.Verify_Search_SearchButton();
        }

        [Test]
        [Category("SearchScreen")]
        public void m_Verify_Tapping_SaveSearch_Shows_Dialog()
        {
            _searchScreen.Verify_Search_SaveSearchButton();
        }

        [Test]
        [Category("SearchScreen")]
        public void n_Verify_All_Years_Chevy_MoreThanALLisLoaded()
        {
            _searchScreen.Verify_Search_AllYears_Chevrolet();
        }


        [Test]
        [Category("SearchScreen")]
        public void o_Verify_Tapping_Cancel_Shows_SearchScreen()
        {
            _searchScreen.Verify_SavedSearch_CancelButton();
        }

        [Test]
        [Category("SearchScreenOrderedTest")]
        public void SearchScreen_OrderedTests()
        {
            a_OpenSearchFromDrawer(); //AC 1, 1.1
            b_Verify_Locations_Has_Data(); //AC 2
            CloseDialog(); //Done button
            c_Verify_Branding_Has_Data(); //AC 7
            CloseDialog(); //Cancel button
            d_Verify_Years_Has_Data(); //AC 4
            CloseDialog(); //Cancel button
            f_Verify_Makes_Has_Data(); //AC 5
            CloseDialog(); //Cancel button
            g_Verify_Models_Has_Data(); //AC 6
            CloseDialog(); //Cancel button
            h_Verify_Types_Has_Data(); //AC 3
            CloseDialog(); //Cancel button
            i_Verify_1950_LessThan_10Makes(); //AC 4.1
            CloseDialog(); //Cancel button
            j_Verify_1950_Chevy_LessThan_10Models(); //AC 4.2
            CloseDialog(); //Cancel button
            k_Verify_AllYears_MoreThan_2Makes_AllModels(); //AC 5.1
            CloseDialog(); //Cancel button
            l_Verify_Tapping_Search_Shows_Results(); //AC 8
            Settings.AppContext.Back();
            m_Verify_Tapping_SaveSearch_Shows_Dialog(); //AC 9
            CloseDialog(); //Cancel button
            n_Verify_All_Years_Chevy_MoreThanALLisLoaded(); //AC 6.1
            CloseDialog(); //Cancel button
            o_Verify_Tapping_Cancel_Shows_SearchScreen(); //AC 9         
        }

        public void CloseDialog()
        {

            if (Settings.AppContext.Query(c => c.Marked("btnDone")).Count() >= 1)
            {
                Settings.AppContext.Tap(DoneButton);
                _searchScreen.Successful = true;
            }
            else if (Settings.AppContext.Query(c => c.Marked("button2")).Count() >= 1)
            {
                Settings.AppContext.Tap(CancelButton);
                _searchScreen.Successful = true;
            }

            Assert.That(_searchScreen.Successful, "I do not see the Done button or the Cancel button!");
        }

        [Test]
        [Category("SearchScreen")]
        public void SearchClearanceVehicles()
        {
            _searchScreen.Search_Clearance_All();
            _searchScreen.Verify_ClearanceResults();
        }

        [Test]
        [Category("SearchScreen")]
        public void SearchAllYardsAllTypes()
        {
            _searchScreen.Search_AllYardsAllTypes();
        }
    }
}