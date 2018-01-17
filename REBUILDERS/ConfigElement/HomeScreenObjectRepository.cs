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
    public class HomeScreenObjectRepository: BasePageObjectRepository
    {
        public static IApp app;
        public int seconds = 30;
        public string locationH;
        public SearchResultsScreen searchResults;
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
            App.WaitForElement(c => c.Property("contentDescription").Like("lblWelcome"));
            App.WaitForElement(c => c.Property("contentDescription").Like("lblPreferredLocation"));
            App.WaitForElement(c => c.Property("contentDescription").Like("lblPreferredLocationDescription"));
            App.WaitForElement(c => c.Property("contentDescription").Like("pkLocations"));
            App.WaitForElement(c => c.Property("contentDescription").Like("btnDone"));
            Console.WriteLine("Verify that the controls on the Home Screen appear as expected in screenshot");
            App.Screenshot("Verify that the controls on the Home Screen appear as expected");
        }

        public void InitialLoad_LocationSetDominion()
        {
          SearchResultsScreen search = new SearchResultsScreen(app);

        }

        public string getLocation()
        {
            return locationH;
        }

        public void setLocation(string loc)
        {
            locationH = loc;
        }

        public void SelectDominion()
        {
            TapEditText();
            App.Tap("LKQ Dominion");
            Assert.AreEqual("LKQ Dominion", App.Query(pkLocationsQuery)[0].Text, "View this screenshot to verify that the location selected was LKQ Dominion");
            App.Screenshot("Verify that the location selected was: " + locationH);
            Console.WriteLine("View this screenshot to verify that the location selected was LKQ Dominion");
        }

        public void SelectHeadlineAuto()
        {
            TapEditText();
            App.Tap("LKQ Headline Auto");
            Assert.AreEqual("LKQ Headline Auto", App.Query(pkLocationsQuery)[0].Text, "View this screenshot to verify that the location selected was LKQ Headline Auto");
            App.Screenshot("Verify that the location selected was LKQ Headline Auto");
            Console.WriteLine("View this screenshot to verify that the location selected was LKQ Headline Auto");
        }

        public void SelectLondon()
        {
            TapEditText();
            App.Tap("LKQ London");
            Assert.AreEqual("LKQ London", App.Query(pkLocationsQuery)[0].Text, "View this screenshot to verify that the location selected was LKQ London");
            App.Screenshot("Verify that the location selected was LKQ London");
            Console.WriteLine("View this screenshot to verify that the location selected was LKQ London");
        }

        public void SetControls()
        {
            lblWelcomeQuery = c => c.Property("contentDescription").Like("lblWelcome");
            lblPreferredLocationQuery = c => c.Property("contentDescription").Like("lblPreferredLocation");
            lblPreferredLocationDescriptionQuery = c => c.Property("contentDescription").Like("lblPreferredLocationDescription");
            pkLocationsQuery = c => c.Property("contentDescription").Like("pkLocations");
            btnDoneQuery = c => c.Property("contentDescription").Like("btnDone");
        }

        public SearchResultsScreen SettingPreferredLocation(string loc)
        {
            setLocation(locationH);
            switch (locationH)
            {
                case "LKQ London":
                    SelectLondon();
                    break;

                case "LKQ Dominion":
                    SelectDominion();
                    //setLocation("LKQ Dominion");
                    break;

                case "LKQ Headline Auto":
                    SelectHeadlineAuto();
                    break;

                default:
                    App.Screenshot("Inspect this screenshot, something went wrong");
                    Console.WriteLine("Inspect this screenshot, something went wrong");
                    break;
            }
            TapBtnDone();
            //SearchResultsScreen search = new SearchResultsScreen(App);
            searchResults.ObjectRepository.setLocation(locationH);
            //Console.WriteLine(search.ObjectRepository.getLocation());
            return searchResults;
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