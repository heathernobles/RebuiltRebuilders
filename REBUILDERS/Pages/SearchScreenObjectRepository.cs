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
    public class SearchScreenObjectRepository : BasePageObjectRepository
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

        public SearchScreenObjectRepository(IApp app) : base(app)
        { }

        public void InitialLoad_PreferredLocationSet(string loc)
        {
            SetWaitTime(seconds);
            setLocation(loc);
            App.WaitForElement(c => c.Marked("btnSavedSearches"), timeout: wait);
            btnSavedSearchesQuery = c => c.Marked("btnSavedSearches");
            App.WaitForElement(c => c.Marked("btnSearch"), timeout: wait);
            btnSearchQuery = c => c.Marked("btnSearch");
            App.WaitForElement(c => c.Marked("lblYearMakeModel"), timeout: wait);
            lblYearMakeModelQuery = c => c.Marked("lblYearMakeModel");
            App.WaitForElement(c => c.Marked("lblMileage"), timeout: wait);
            lblMileageQuery = c => c.Marked("lblMileage");
            App.WaitForElement(c => c.Marked("lblFileNumber"), timeout: wait);
            lblFileNumberQuery = c => c.Marked("lblFileNumber");
            App.WaitForElement(c => c.Marked("lblValue"), timeout: wait);
            lblValueQuery = c => c.Marked("lblValue");
            App.WaitForElement(c => c.Marked("lblClearance"), timeout: wait);
            lblClearanceQuery = c => c.Marked("lblClearance");
            App.WaitForElement(c => c.Marked("lblLocation"), timeout: wait);
            lblLocationQuery = c => c.Marked("lblLocation");
            App.WaitForElement(c => c.Marked("lblBranding"), timeout: wait);
            lblBrandingQuery = c => c.Marked("lblBranding");
            App.WaitForElement(c => c.Marked("imgVehItem"), timeout: wait);
            imgVehItemQuery = c => c.Marked("imgVehItem");
            Console.WriteLine("Verify that the controls on the Search Results Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Search Results Screen appear as expected");
            VerifyLocationResults(loc);
            Console.WriteLine("Verify that the search results are from location: " + getLocation());
            App.Screenshot("Verify that the search results are from location: " + getLocation());
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

        public string getLocation()
        {
            return location;
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
                App.Screenshot("Result " + i + " location is: " + results[i].Text);
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
                App.Screenshot("Result " + i + " location is: " + results[i].Text);
                i++;
            }
            App.Screenshot("Verify that the search results are all from location: " + getLocation());
        }
    }
}
