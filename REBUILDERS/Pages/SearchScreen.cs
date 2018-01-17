using System;
using Rebuilders.Utils;
using Xamarin.UITest.Queries;
using NUnit.Framework;
using Xamarin.UITest;
using System.Linq;

namespace Rebuilders.Pages
{
    public class SearchScreen : BasePage
    {
        public Query Page { get; } = new Query(x => x.Marked("cpSearch"));
        public Query LocationsPicker { get; } = new Query(x => x.Marked("txtLocations"));
        public Query VehicleTypesPicker { get; } = new Query(x => x.Marked("pkVehicleType"));
        public Query YearsFromPicker { get; } = new Query(x => x.Marked("pkYearFrom"));
        public Query YearsToPicker { get; } = new Query(x => x.Marked("pkYearTo"));
        public Query MakesPicker { get; } = new Query(x => x.Marked("pkMake"));
        public Query ModelsPicker { get; } = new Query(x => x.Marked("pkModel"));
        public Query BrandsPicker { get; } = new Query(x => x.Marked("pkBrand"));
        public Query SearchButton { get; } = new Query(x => x.Marked("btnSearch"));
        public Query SaveSearchButton { get; } = new Query(x => x.Marked("btnSaveSearch"));
        public Query ClearanceSwitch { get; } = new Query(x => x.Marked("swcClearance"));
        public bool Successful;
        private LocationsScreen _locationsScreen;
        private PickerDialog _pickerDialog;
        private VehicleDetailsScreen _detailsScreen;
        private SearchResultsScreen _resultsScreen;
        private EntryDialog _entryDialog;
        private Drawer _drawer;

        public SearchScreen(IApp app) : base(app)
        {
            _locationsScreen = new LocationsScreen(app);
            _pickerDialog = new PickerDialog(app);
            _detailsScreen = new VehicleDetailsScreen(app);
            _resultsScreen = new SearchResultsScreen(app);
            _entryDialog = new EntryDialog(app);
            _drawer = new Drawer(app);
            Successful = false;
        }

        [Category("Search")]
        public void SearchScreenLoaded()
        {
            Settings.AppContext.WaitForElement(LocationsPicker);
            Assert.That(GetCount(LocationsPicker) >= 1, "Cannot find the Locations picker");
            Settings.AppContext.WaitForElement(VehicleTypesPicker);
            Assert.That(GetCount(VehicleTypesPicker) >= 1, "Cannot find the Vehicle types picker");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Assert.That(GetCount(YearsFromPicker) >= 1, "Cannot find the Years From picker");
            Settings.AppContext.WaitForElement(YearsToPicker);
            Assert.That(GetCount(YearsToPicker) >= 1, "Cannot find the Years To picker");
            Settings.AppContext.WaitForElement(MakesPicker);
            Assert.That(GetCount(MakesPicker) >= 1, "Cannot find the Makes picker");
            Settings.AppContext.WaitForElement(ModelsPicker);
            Assert.That(GetCount(ModelsPicker) >= 1, "Cannot find the Models picker");
            Settings.AppContext.WaitForElement(BrandsPicker);
            Assert.That(GetCount(BrandsPicker) >= 1, "Cannot find the Brands picker");
            Settings.AppContext.WaitForElement(SearchButton);
            Assert.That(GetCount(SearchButton) >= 1, "Cannot find the Search button");
            Settings.AppContext.WaitForElement(SaveSearchButton);
            Assert.That(GetCount(SaveSearchButton) >= 1, "Cannot find the Save Search button");
            Settings.AppContext.WaitForElement(ClearanceSwitch);
            Assert.That(GetCount(ClearanceSwitch) >= 1, "Cannot find the clearance switch");
            Settings.AppContext.Screenshot("Search Screen loaded successfully");
        }

        [Category("Search")]
        public void Search_Clearance_All()
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.Tap(ClearanceSwitch);
            Settings.AppContext.Screenshot("After clearance switch has been toggled");
            Settings.AppContext.Tap(SearchButton);
            Settings.AppContext.WaitForElement(_resultsScreen.Page);
            var items = _resultsScreen.GetItems();
            Assert.Greater(items.Length, 1, "More than 1 result needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Clearance Search Results");
        }

        [Category("Search")]
        public void WhenDrawerSearchItemTapped_ThenSearchPageAppears()/*WhenDrawerSearchItemTapped_ThenSearchPageAppears
        While app drawer is open, tapping Search link will direct user to the Search screen*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(Page);
            Settings.AppContext.Screenshot("Search Page");
            SearchScreenLoaded();
        }

        [Category("Search")]
        public void WhenSearchPageLoaded_ThenLocationsHasData()/*WhenSearchPageLoaded_ThenLocationsHasData
        When the Search screen loads, more than 1 item will appear in the Locations picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(LocationsPicker);
            Settings.AppContext.Tap(LocationsPicker);

            Settings.AppContext.WaitForElement(_locationsScreen.List);
            var listItems = Settings.AppContext.Query(_locationsScreen.ListLabels);
            Assert.Greater(listItems.Length, 1, "More than 1 location needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Locations Picker");
        }

        [Category("Search")]
        public void WhenSearchPageLoaded_ThenMakesHasData()/*WhenSearchPageLoaded_ThenMakesHasData
        When the Search screen loads, more than 1 item will appear in the Makes picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(MakesPicker);
            Settings.AppContext.Tap(MakesPicker);

            _pickerDialog.WaitToAppear();
            var pickerItems = Settings.AppContext.Query(_pickerDialog.Items);
            Assert.Greater(pickerItems.Length, 1, "More than 1 Make needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Makes Picker");
        }

        [Category("Search")]
        public void WhenSearchPageLoaded_ThenModelsHasData()/*WhenSearchPageLoaded_ThenModelsHasData
        When the Search screen loads, more than 1 item will appear in the Models picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(ModelsPicker);
            Settings.AppContext.Tap(ModelsPicker);

            _pickerDialog.WaitToAppear();
            var pickerItems = Settings.AppContext.Query(_pickerDialog.Items);
            Assert.Greater(pickerItems.Length, 1, "More than 1 Model needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Model Picker");
        }

        [Category("Search")]
        public void WhenSearchPageLoaded_ThenVehicleTypeHasData()/*WhenSearchPageLoaded_ThenVehicleTypeHasData
        When the Search screen loads, more than 1 item will appear in the Vehicle Types picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(VehicleTypesPicker);
            Settings.AppContext.Tap(VehicleTypesPicker);

            _pickerDialog.WaitToAppear();
            var pickerItems = Settings.AppContext.Query(_pickerDialog.Items);
            Assert.Greater(pickerItems.Length, 1, "More than 1 vehicle type needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Vehicle Types Picker");
        }

        [Category("Search")]
        public void WhenSearchPageLoaded_ThenYearFromToHasData()/*WhenSearchPageLoaded_ThenYearFromToHasData
        When the Search screen loads, more than 1 item will appear in the Years To and Years From pickers*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Settings.AppContext.Tap(YearsFromPicker);

            _pickerDialog.WaitToAppear();
            var pickerItems = Settings.AppContext.Query(_pickerDialog.Items);
            Assert.Greater(pickerItems.Length, 1, "More than 1 year needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Years From Picker");
            Settings.AppContext.Tap(_pickerDialog.DoneButton);

            //Validating year to.
            Settings.AppContext.WaitForElement(YearsToPicker);
            Settings.AppContext.Tap(YearsToPicker);

            _pickerDialog.WaitToAppear();
            pickerItems = Settings.AppContext.Query(_pickerDialog.Items);
            Assert.Greater(pickerItems.Length, 1, "More than 1 year needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Years To Picker");
        }

        [Category("Search")]
        public void WhenSelecting1950_ThenLessThan10MakesAreLoaded()/*WhenSelecting1950_ThenLessThan10MakesAreLoaded
        When selecting Years = 1950, less than 10 makes appear in the Makes picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Settings.AppContext.Tap(YearsFromPicker);
            Settings.AppContext.Screenshot("Years From Picker");
            _pickerDialog.SelectItem("1950");

            Settings.AppContext.Tap(YearsToPicker);
            Settings.AppContext.Screenshot("Years To Picker");
            _pickerDialog.SelectItem("1950");

            Settings.AppContext.Tap(MakesPicker);
            var makeItems = _pickerDialog.GetItems();
            Assert.Greater(makeItems.Length, 1, "More than 1 make needs to be shown on the screen.");
            Assert.Less(makeItems.Length, 10, "Less than 10 makes need to be shown on the screen.");
            Settings.AppContext.Screenshot("Makes Picker");
        }

        [Category("Search")]
        public void Verify_Search_1950_Chevrolet()/*WhenSelecting1950Chevrolet_ThenLessThan5ModelsAreLoaded
        When selecting Years = 1950 and Make = Chevrolet, less than 5 models appear in Model picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Settings.AppContext.Tap(YearsFromPicker);
            Settings.AppContext.Screenshot("Years From Picker");
            _pickerDialog.SelectItem("1950");

            Settings.AppContext.WaitForElement(YearsToPicker);
            Settings.AppContext.Tap(YearsToPicker);
            Settings.AppContext.Screenshot("Years To Picker");
            _pickerDialog.SelectItem("1950");

            Settings.AppContext.Tap(MakesPicker);
            Settings.AppContext.Screenshot("Makes Picker");
            _pickerDialog.SelectItem("Chevrolet");

            Settings.AppContext.Tap(ModelsPicker);
            var modelItems = _pickerDialog.GetItems();
            Assert.Greater(modelItems.Length, 1, "More than 1 model needs to be shown on the screen.");
            Assert.Less(modelItems.Length, 5, "Less than 10 models need to be shown on the screen.");
            Settings.AppContext.Screenshot("Models Picker");
        }

        [Category("Search")]
        public void Verify_Search_AllYears_Chevrolet()/*WhenSelectingChevrolet_MoreThan2ModelsAreLoaded
        When selecting Years = All and Make = Chevrolet, more than 2 models appear in the Models picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Settings.AppContext.Tap(YearsFromPicker);
            Settings.AppContext.Screenshot("Years From Picker");
            _pickerDialog.SelectItem("All");

            Settings.AppContext.WaitForElement(YearsToPicker);
            Settings.AppContext.Tap(YearsToPicker);
            Settings.AppContext.Screenshot("Years To Picker");
            _pickerDialog.SelectItem("All");

            Settings.AppContext.Tap(MakesPicker);
            Settings.AppContext.Screenshot("Makes Picker");
            _pickerDialog.SelectItem("Chevrolet");

            Settings.AppContext.Tap(ModelsPicker);
            var modelItems = _pickerDialog.GetItems();
            Assert.Greater(modelItems.Length, 1, "More than 1 model needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Models Picker");
        }

        [Category("Search")]
        public void Verify_Search_AllYearsSelected()/*WhenAllYearsSelected_ThenMoreThan2MakesExistAndModelIsAll
        When selecting Years = All, more than 2 makes appear in the Makes picker and more than 2 models appear in the Models picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(YearsFromPicker);
            Settings.AppContext.Tap(YearsFromPicker);
            Settings.AppContext.Screenshot("Years From Picker");
            _pickerDialog.SelectItem("All");

            Settings.AppContext.WaitForElement(YearsToPicker);
            Settings.AppContext.Tap(YearsToPicker);
            Settings.AppContext.Screenshot("Years To Picker");
            _pickerDialog.SelectItem("All");

            Settings.AppContext.Tap(MakesPicker);
            Settings.AppContext.Screenshot("Makes Picker");
            _pickerDialog.SelectItem("Chevrolet");
            Settings.AppContext.WaitForElement(MakesPicker);
            Settings.AppContext.Tap(MakesPicker);
            var makeItems = _pickerDialog.GetItems();
            Assert.Greater(makeItems.Length, 2, "More than 2 makes need to be shown on the screen.");
            _pickerDialog.Close();

            Settings.AppContext.Tap(ModelsPicker);
            var modelItems = _pickerDialog.GetItems();
            Assert.Greater(modelItems.Length, 1, "The models picker should contain more than 1 item.");
            Settings.AppContext.Screenshot("Models Picker");
        }

        [Category("Search")]
        public void Verify_Search_BrandsPicker()/*WhenSearchPageLoaded_ThenBrandsHasData
        When the search screen loads, more than 1 item will appear in the Brands picker*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(BrandsPicker);
            Settings.AppContext.Tap(BrandsPicker);
            var brandItems = _pickerDialog.GetItems();
            Assert.Greater(brandItems.Length, 1, "More than 1 brand needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Brands Picker");
        }

        [Category("Search")]
        public void Verify_Search_SearchButton()/*WhenTapOnSearch_ThenResultsShown
        While on the Search screen, tapping search will show the results from the currently selected search criteria*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(SearchButton);
            Settings.AppContext.Tap(SearchButton);

            Settings.AppContext.WaitForElement(_resultsScreen.Page);
            var items = _resultsScreen.GetItems();
            Assert.Greater(items.Length, 1, "More than 1 result needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Search Results");
        }

        [Category("Search")]
        public void Verify_Search_SaveSearchButton()/*WhenTapOnSaveSearch_DialogShowsUp
        While on the Search screen, tapping the Save Search button display the Save Search Dialog*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(SaveSearchButton);
            Settings.AppContext.Tap(SaveSearchButton);

            _entryDialog.WaitToAppear();
            var entryText = _entryDialog.GetEntryText();
            Assert.IsFalse(string.IsNullOrWhiteSpace(entryText));
            Settings.AppContext.Screenshot("Save Search Dialog");
        }

        [Category("Search")]
        public void Verify_SavedSearch_CancelButton()/*WhenCancelSaveSearch_ThenSearchScreenShown
        While on the Search screen, tapping the Cancel button will return user to the Search Screen in its most recent state*/
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(SaveSearchButton);
            Settings.AppContext.Tap(SaveSearchButton);

            _entryDialog.WaitToAppear();
            Settings.AppContext.Screenshot("Before clicking Cancel");
            _entryDialog.TapCancelButton();

            Settings.AppContext.WaitForElement(Page);
            Settings.AppContext.Screenshot("After clicking Cancel");
        }

        [Category("Results")]
        public void Verify_ClearanceResults()
        //When Search criteria = Clearance, all items on the Search Results screen will display the red Clearance label to the right of the price*/
        {
            int i = 0;
            Settings.AppContext.WaitForElement(c => c.Marked("lblClearance"));

            results = Settings.AppContext.Query(c => c.Marked("lblClearance").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual("Clearance", (results)[i].Text, "This is not a clearance vehicle");
                Console.WriteLine("Result " + i + " clearance status is: " + results[i].ToString());
                Settings.AppContext.Screenshot("Result " + i + " clearance status is: " + results[i].Text);
                i++;
            }
        }

        [Category("Results")]
        public void Search_AllYardsAllTypes()
        //When Search criteria = All Yards, All Vehicle Types - Search Results screen will display more than 1 item
        {
            _drawer.NavigateTo("Search");
            Settings.AppContext.WaitForElement(VehicleTypesPicker);
            Settings.AppContext.Tap(VehicleTypesPicker);
            Settings.AppContext.Screenshot("Vehicle Types Picker");
            _pickerDialog.SelectItem("All");
            Settings.AppContext.Screenshot("Current Search Criteria");
            Settings.AppContext.WaitForElement(SearchButton);
            Settings.AppContext.Tap(SearchButton);

            Settings.AppContext.WaitForElement(_resultsScreen.Page);
            var items = _resultsScreen.GetItems();
            Assert.Greater(items.Length, 1, "More than 1 result needs to be shown on the screen.");
            Settings.AppContext.Screenshot("Search Results");
        }
    }
}