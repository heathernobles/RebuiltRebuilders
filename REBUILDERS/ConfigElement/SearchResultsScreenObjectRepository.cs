using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Rebuilders.Pages
{
    public class SearchResultsScreenObjectRepository : BasePageObjectRepository
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
            setLocation(loc);
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
            Console.WriteLine("Verify that the search results are from location: " + getLocation());
            App.Screenshot("Verify that the search results are from location: " + getLocation());
        }

        public string getLocation()
        {
            return location;
        }

        public void SetControls()
        {
            btnSavedSearchesQuery = c => c.Property("contentDescription").Like("btnSavedSearches");
            btnSearchQuery = c => c.Property("contentDescription").Like("btnSearch");
            lblYearMakeModelQuery = c => c.Property("contentDescription").Like("lblYearMakeModel");
            lblMileageQuery = c => c.Property("contentDescription").Like("lblMileage");
            lblFileNumberQuery = c => c.Property("contentDescription").Like("lblFileNumber");
            lblValueQuery = c => c.Property("contentDescription").Like("lblValue");
            lblClearanceQuery = c => c.Property("contentDescription").Like("lblClearance");
            lblLocationQuery = c => c.Property("contentDescription").Like("lblLocation");
            lblBrandingQuery = c => c.Property("contentDescription").Like("lblBranding");
            imgVehItemQuery = c => c.Property("contentDescription").Like("imgVehItem");
            Console.WriteLine("Verify that the controls on the Search Results Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Search Results Screen appear as expected");
        }

        public void setLocation(string loc)
        {
            location = loc;
        }

        public void VerifyLocationResults()
        {
            int i = 0;
            App.WaitForElement(c => c.Property("contentDescription").Like("lblLocation"));
            results = App.Query(c=>c.Property("contentDescription").Like("lblLocation").All());
            foreach( AppResult result in results)
                {
                Assert.AreEqual(location, (results)[i].Text, "This is not the expected location!");
                Console.WriteLine("Result " + i + " location is: " + results[i].Text);
                i++;
                }
            App.Screenshot("Verify that the search results are all from location: " + getLocation());
        }

        public void VerifyLocationResults(string loc)
        {
            setLocation(loc);
            int i = 0;
            App.WaitForElement(c => c.Property("contentDescription").Like("lblLocation"));
            results = App.Query(c => c.Property("contentDescription").Like("lblLocation").All());
            foreach (AppResult result in results)
            {
                Assert.AreEqual(location, (results)[i].Text, "This is not the expected location!");
                Console.WriteLine("Result " + i + " location is: " + results[i].Text);
                i++;
            }
            App.Screenshot("Verify that the search results are all from location: " + getLocation());

        }

        public void FullSweepLocation(string loc)
        {
            
        }

    }
}
