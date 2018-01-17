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
    public class DrawerObjectRepository : BasePageObjectRepository
    {
        public static IApp app;
        public int seconds = 30;
        public AppResult[] results;
        public string location;
        public Query menuButtonQuery; //OK
        public Query menuHomeQuery;
        public Query menuSearchQuery;
        public Query menuSavedSearchesQuery;
        public Query menuSettingsQuery;
        
        public DrawerObjectRepository(IApp app) : base(app)
        { InitializeVariables();}


        public void InitialLoadDrawer()
        {
            App.WaitForElement(c => c.Marked("Home"), timeout: wait);
            App.Screenshot("Verified that the Home item exists");
            App.WaitForElement(c => c.Marked("Search"), timeout: wait);
            App.Screenshot("Verified that the Search item exists");
            App.WaitForElement(c => c.Marked("Saved Searches"), timeout: wait);
            App.Screenshot("Verified that the Saved Searches item exists");
            App.WaitForElement(c => c.Marked("Settings"), timeout: wait);
            App.Screenshot("Verified that the Settings item exists");
        }

        public void InitializeVariables()
        {
            SetWaitTime(seconds);
            menuButtonQuery = c => c.Marked("OK");
            menuHomeQuery = c => c.Marked("Home");
            menuSearchQuery = c => c.Marked("Search");
            menuSavedSearchesQuery = c => c.Marked("Saved Searches");
            menuSettingsQuery = c => c.Marked("Settings");
        }

        public void OpenDrawer()
        {
            App.Tap(menuButtonQuery);
        }

        public void TapItem(string item)
        {
            App.Tap(item);
        }

        public SearchResultsScreen TapSettings()
        {
            App.Tap(menuSettingsQuery);
            SearchResultsScreen settings = new SearchResultsScreen(App);
            return settings;
        }
    }
}
