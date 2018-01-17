using NUnit.Framework;
using Rebuilders.Utils;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Rebuilders.Pages
{   
    public class SavedSearchesScreen: BasePage
    {
        private Drawer _drawer;
        private EntryDialog _entryDialog;
        private SearchResultsScreen _resultsScreen;
        private SearchScreen _searchScreen;
        public Query MenuButton = new Query("OK");
        public Query xDeleteSavedSearch = new Query("imgDelete");
        public Query lblAlertTitle = new Query("alertTitle");
        public Query lblMessage = new Query("lblMessage");
        public Query btnDelete = new Query("button1");
        public Query btnCancel = new Query("button2");
        public Query btnSavedSearches = new Query("btnSavedSearches");
        public Query ItemLabels { get; } = new Query(c=>c.Marked("lblText"));
        public int SavedSearchCount = 0;
        public Query swLocationSelected = new Query("swcSelected");

        public SavedSearchesScreen(IApp app): base(app)
        {
            _drawer = new Drawer(app);
            _entryDialog = new EntryDialog(app);
            _resultsScreen = new SearchResultsScreen(app);
            _searchScreen = new SearchScreen(app);
            SetWaitTime(30);
        }

        public void WaitToAppear()
        {
            Settings.AppContext.WaitForElement("cpSavedSearches");
        }

        public AppResult[] GetItemLabels()
        {
            SavedSearchCount = Settings.AppContext.Query(ItemLabels).Count();
            return Settings.AppContext.Query(ItemLabels);
        }

        public void TapOnItem(string text)
        {
            Settings.AppContext.Tap(GetItem(text));
        }

        public Query GetItem(string text)
        {
            return new Query(c => c.Marked("lblText").Text(text));
        }

        public void WhenSaveSearch_ThenSearchSaved()
        {
            _drawer.NavigateTo("Search");

            Settings.AppContext.WaitForElement(_searchScreen.SaveSearchButton);
            _searchScreen.SearchScreenLoaded();
            Settings.AppContext.Tap(_searchScreen.SaveSearchButton);

            _entryDialog.WaitToAppear();
            var entryText = _entryDialog.GetEntryText();
            Settings.AppContext.Screenshot("Verifying the Saved Search name is as expected");
            _entryDialog.TapAcceptButton();

            _drawer.NavigateTo("Saved Searches");

            WaitToAppear();
            var texts = GetItemLabels().Select(c => c.Text).ToArray();           
            Assert.IsTrue(texts.Any(c => string.Equals(c, entryText)), $"The saved search \"{entryText}\" should exist in the saved searches screen.");
            Settings.AppContext.Screenshot("Verifying that the newly saved search appears in the Saved Searches list");
        }

        public void WhenSavedSearchTapped_ThenResultsScreenShown()
        {
            _drawer.NavigateTo("Saved Searches");

            WaitToAppear();
            var labels = GetItemLabels();
            if (labels.Length == 0) Assert.Inconclusive("Cannot run test. Please create a saved search first.");
            Settings.AppContext.Screenshot("Verifying that the saved search appears in the Saved Searches list");
            TapOnItem(labels[0].Text);

            _resultsScreen.WaitToAppear();

            Settings.AppContext.WaitForElement(_resultsScreen.ResultsListView);
            _resultsScreen.WaitForLoadedResults();
        }

        public void Add_VehicleType_to_SavedSearch()
        {

        }

        public void Verify_SavedSearches_ButtonExists()
        {
            _drawer.NavigateTo("Home");          
            Assert.That(Settings.AppContext.Query(btnSavedSearches).Count() >= 1);
            Settings.AppContext.Screenshot("Do you see the SavedSearches button?");
        }

        public void Delete_SavedSearch()
        {
            Settings.AppContext.Screenshot("Showing current SavedSearches");
            Settings.AppContext.WaitForElement("imgDelete", timeoutMessage: "No Saved Searches Available", timeout: GetWaitObj());
            int c = Settings.AppContext.Query(xDeleteSavedSearch).Count();
            Settings.AppContext.Tap("imgDelete");
            Settings.AppContext.Screenshot("Delete Saved Search confirmation dialog");
            Assert.GreaterOrEqual(Settings.AppContext.Query(lblAlertTitle).Count(), 1);
            Settings.AppContext.Tap(btnDelete);
            c--;
            Settings.AppContext.Screenshot("Showing current SavedSearches");
            //Settings.AppContext.Query("lblText");
            Assert.AreEqual(Settings.AppContext.Query("lblText").Count(),c);
            Assert.That(Settings.AppContext.Query(lblMessage).Count()>=1);
        }

        public void Verify_MultiYard_SavedSearch()
        {
            LocationsScreen locations = new LocationsScreen(Settings.AppContext);
            Settings.AppContext.Tap(_searchScreen.SearchButton);
            Settings.AppContext.Tap(_searchScreen.LocationsPicker);
            Settings.AppContext.WaitForElement(c => c.Switch());

            locations.AddAllLocationsToSearch();
            Settings.AppContext.WaitForElement(_searchScreen.SaveSearchButton);
            _searchScreen.SearchScreenLoaded();
            Settings.AppContext.Tap(_searchScreen.SaveSearchButton);

            _entryDialog.WaitToAppear();
            var entryText = _entryDialog.GetEntryText();
            Settings.AppContext.Screenshot("Verifying the Saved Search name is as expected");
            _entryDialog.TapAcceptButton();

            _drawer.NavigateTo("Saved Searches");

            WaitToAppear();
            var texts = GetItemLabels().Select(c => c.Text).ToArray();
            Assert.IsTrue(texts.Any(c => string.Equals(c, entryText)), $"The saved search \"{entryText}\" should exist in the saved searches screen.");
            Settings.AppContext.Screenshot("Verify that the name of the Saved Search includes number of locations instead of location name");
        }
    }
}