using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Rebuilders.Utils;


namespace Rebuilders.Pages
{
    public class HomeScreenObjectRepository: BasePageObjectRepository
    {
        public static IApp app;
        public int seconds = 30;
        public string locationH;
        public AppResult[] results;
        public Query lblWelcomeQuery;
        public Query lblPreferredLocationQuery;
        public Query lblPreferredLocationDescriptionQuery;
        public Query pkLocationsQuery;
        public Query btnDoneQuery;


        public HomeScreenObjectRepository(IApp app) : base(app)
        { }

        public void InitialLoad_FirstInstalled()
        {
            App.WaitForElement(c => c.Marked("lblWelcome"));
            App.WaitForElement(c => c.Marked("lblPreferredLocation"));
            App.WaitForElement(c => c.Marked("lblPreferredLocationDescription"));
            App.WaitForElement(c => c.Marked("pkLocations"));
            App.WaitForElement(c => c.Marked("btnDone"));
            Console.WriteLine("Verify that the controls on the Home Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Home Screen appear as expected");
        }

        /*public void InitializeHomeVariables()
        {
            lblWelcomeQuery = c => c.Marked("lblWelcome");
            lblPreferredLocationQuery = c => c.Property("contentDescription").Like("lblPreferredLocation");
            lblPreferredLocationDescriptionQuery = c => c.Property("contentDescription").Like("lblPreferredLocationDescription");
            pkLocationsQuery = c => c.Property("contentDescription").Like("pkLocations");
            btnDoneQuery = c => c.Property("contentDescription").Like("btnDone");
        }*/


        public string getLocation()
        {
            return locationH;
        }

        public void setLocation(string loc)
        {
            locationH = loc;
        }

        public void SelectLocation(string loc)
        {
            TapEditText();
            App.Tap(loc);
            App.WaitForElement(pkLocationsQuery);
            App.Screenshot("Verify that the location selected was: " + loc);
            Assert.AreEqual(loc, App.Query(pkLocationsQuery)[0].Text, "View this screenshot to verify that the location selected was LKQ Dominion");
            Console.WriteLine("View this screenshot to verify that the location selected was: " + loc);
            setLocation(loc);
        }


        public SearchResultsScreen SettingPreferredLocation()
        {
            string loc = getLocation();
            TapBtnDone();
            SearchResultsScreen search = new SearchResultsScreen(App);
            search.ObjectRepository.setLocation(loc);
            return search;
        }

        //SRP Methods
        public void TapBtnDone()
        {
            App.Tap(btnDoneQuery);
        }
        
        public void TapEditText()
        {
            App.Tap(pkLocationsQuery);
        }

    }
}