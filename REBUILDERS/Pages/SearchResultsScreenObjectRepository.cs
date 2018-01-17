using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Rebuilders.Pages
{
    public class SearchResultsScreenObjectRepository  : BasePageObjectRepository
    {
        public int seconds = 30;
        public AppResult[] results;
        public string location;
        public Query btnSavedSearchesQuery;
        public Query btnSearchQuery;
        public Query lblYearMakeModelQuery;
        public Query lblMileageQuery;
        public Query lblFileNumberQuery;
        public Query lblValueQuery;
        public Query lblClearanceQuery;
        public Query lblLocationQuery;
        public Query lblBrandingQuery;
        public Query imgVehItemQuery;

        public SearchResultsScreenObjectRepository(IApp app) : base(app)
        { }

        public void InitialLoad_PreferredLocationSet(string loc)
        {
            SetWaitTime(seconds);
            location = loc;
            App.WaitForElement(c => c.Property("contentDescription").Like("btnSavedSearches"), timeout: wait);
            btnSavedSearchesQuery = c => c.Property("contentDescription").Like("btnSavedSearches");
            App.WaitForElement(c => c.Property("contentDescription").Like("btnSearch"), timeout: wait);
            btnSearchQuery = c => c.Property("contentDescription").Like("btnSearch");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblYearMakeModel"), timeout: wait);
            lblYearMakeModelQuery = c => c.Property("contentDescription").Like("lblYearMakeModel");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblMileage"), timeout: wait);
            lblMileageQuery = c => c.Property("contentDescription").Like("lblMileage");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblFileNumber"), timeout: wait);
            lblFileNumberQuery = c => c.Property("contentDescription").Like("lblFileNumber");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblValue"), timeout: wait);
            lblValueQuery = c => c.Property("contentDescription").Like("lblValue");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblClearance"), timeout: wait);
            lblClearanceQuery = c => c.Property("contentDescription").Like("lblClearance");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblLocation"), timeout: wait);
            lblLocationQuery = c => c.Property("contentDescription").Like("lblLocation");
            App.WaitForElement(c => c.Property("contentDescription").Like("lblBranding"), timeout: wait);
            lblBrandingQuery = c => c.Property("contentDescription").Like("lblBranding");
            App.WaitForElement(c => c.Property("contentDescription").Like("imgVehItem"), timeout: wait);
            imgVehItemQuery = c => c.Property("contentDescription").Like("imgVehItem");
            Console.WriteLine("Verify that the controls on the Search Results Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Search Results Screen appear as expected");
            VerifyLocationResults(loc);
            Console.WriteLine("Verify that the search results are from location: " + location);
            App.Screenshot("Verify that the search results are from location: " + location);
        }


        public void InitializeSearchVariables()
        {
            btnSavedSearchesQuery = c => c.Marked("btnSavedSearches");
            btnSearchQuery = c => c.Marked("btnSearch");
            lblYearMakeModelQuery = c => c.Marked("lblYearMakeModel");
            lblMileageQuery = c => c.Marked("lblMileage");
            lblFileNumberQuery = c => c.Marked("lblFileNumber");
            lblValueQuery = c => c.Marked("lblValue");
            lblClearanceQuery = c => c.Marked("lblClearance");
            lblLocationQuery = c => c.Marked("lblLocation");
            lblBrandingQuery = c => c.Marked("lblBranding");
            imgVehItemQuery = c => c.Marked("imgVehItem");
            Console.WriteLine("Verify that the controls on the Search Results Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Search Results Screen appear as expected");
        }


        public void VerifyLocationResults()
        {
            int i = 0;
            App.WaitForElement(c => c.Marked("lblLocation"));
            results = App.Query(c => c.Marked("lblLocation").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual(location, (results)[i].Text, "This is not the expected location!");
                Console.WriteLine("Result " + i + " location is: " + results[i].Text);
                App.Screenshot("Result " + i + " location is: " + results[i].Text);
                i++;
            }
            App.Screenshot("Verify that the search results are all from location: " + location);
        }

        public void VerifyLocationResults(string loc)
        {
            location = loc;
            int i = 0;
            App.WaitForElement(c => c.Property("contentDescription").Like("lblLocation"));
            results = App.Query(c => c.Property("contentDescription").Like("lblLocation").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual(location, (results)[i].Text, "This is not the expected location!");
                Console.WriteLine("Result " + i + " location is: " + results[i].Text);
                App.Screenshot("Result " + i + " location is: " + results[i].Text);
                i++;
            }
            App.Screenshot("Verify that the search results are all from location: " + location);
        }
    }
}
