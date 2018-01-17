using NUnit.Framework;
using Rebuilders.Utils;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Rebuilders.Pages
{
    public class SearchResultsScreen : BasePage
    {
        public Query Page { get; } = new Query(c => c.Marked("cpResults"));
        public Query ResultsListView { get; } = new Query(c => c.Marked("lvResults"));
        public Query ResultListItem { get; } = new Query(c => c.Marked("slVehItem"));
        public Query ResultListLocation { get; } = new Query(c => c.Marked("lblLocation"));
        public Query ResultListClearance { get; } = new Query(c => c.Marked("lblClearance"));
        public string location;
        public bool clearance = false;

        public SearchResultsScreen(IApp app) : base(app)
        {}

        public void WaitToAppear()
        {
            Settings.AppContext.WaitForElement(Page);
        }

        public void WaitForLoadedResults()
        {
            Settings.AppContext.WaitForElement(ResultsListView);
            SetCount(ResultsListView);
            Settings.AppContext.Screenshot("Verify that there are: " + GetCount(ResultsListView) + " results");
        }

        public AppResult[] GetItems()
        {
            Settings.AppContext.WaitForElement(ResultsListView);
            return Settings.AppContext.Query(ResultListItem);
        }

        public string GetLocation()
        {
            location = Settings.AppContext.Query(ResultListLocation)[0].Text;
            return location;
        }
        
        public VehicleDetailsScreen SelectVehicle()
        {
            Settings.AppContext.Tap(ResultListItem);
            VehicleDetailsScreen details = new VehicleDetailsScreen(Settings.AppContext);
            Settings.AppContext.WaitForElement(details.lblValue);
            return details;
        }

        public void VerifyLocationResults()
        {
            int i = 0;
            Settings.AppContext.WaitForElement(ResultListLocation);
            location = GetLocation();
            results = Settings.AppContext.Query(c => c.Marked("lblLocation").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual(location, (results)[i].Text, "This is not the expected location!");
                Console.WriteLine("Result " + i + " location is: " + results[i].Text);
                Settings.AppContext.Screenshot("Result " + i + " location is: " + results[i].Text);
                i++;
            }
            Settings.AppContext.Screenshot("Verify that the search results are all from location: " + location);
        }

        public void VerifyClearanceResults()
        {
            int i = 0;
            Settings.AppContext.WaitForElement(ResultListClearance);

            results = Settings.AppContext.Query(c => c.Marked("lblClearance").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual(true, (results)[i].ToString(), "This is not a clearance vehicle");
                Console.WriteLine("Result " + i + " clearance status is: " + results[i].ToString());
                Settings.AppContext.Screenshot("Result " + i + " clearance status is: " + results[i].Text);
                i++;
            }
            Settings.AppContext.Screenshot("Verify that the search results are all clearance vehicles");
            Settings.AppContext.Repl();
        }

        public void VerifySearchCriteriaShowsHides()
        {

        }

    }
}