using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using Rebuilders.Utils;
using System.Threading;

namespace Rebuilders.Pages
{
    public class HomeScreen: BasePage
    {
        public static IApp app;
        public int seconds = 30;
        public string location;
        public Query lblWelcomeQuery { get; } = new Query(c => c.Marked("lblWelcome"));
        public Query lblPreferredLocationQuery { get; } = new Query(c => c.Marked("lblPreferredLocation"));
        public Query lblPreferredLocationDescriptionQuery { get; } = new Query(c => c.Marked("lblPreferredLocationDescription"));
        public Query pkLocationsQuery { get; } = new Query(c => c.Marked("pkLocations"));
        public Query btnDoneQuery { get; } = new Query(c => c.Marked("btnDone"));
        public bool locationSet = false;

        public HomeScreen(IApp app): base(app)
        { }

        public void InitialLoad_FirstInstalled()
        {
            Settings.AppContext.WaitForElement(c => c.Marked("lblWelcome"));
            Settings.AppContext.WaitForElement(c => c.Marked("lblPreferredLocation"));
            Settings.AppContext.WaitForElement(c => c.Marked("lblPreferredLocationDescription"));
            Settings.AppContext.WaitForElement(c => c.Marked("pkLocations"));
            Settings.AppContext.WaitForElement(c => c.Marked("btnDone"));
            Console.WriteLine("Verify that the controls on the Home Screen appear as expected in screenshot");
            Settings.AppContext.Screenshot("Verify that the controls on the Home Screen appear as expected");
        }

        public void SelectLocation(string loc)
        {
            Thread.Sleep(300);
            if (Settings.AppContext.Query(lblWelcomeQuery).Count()>= 1)
            {
                TapEditText();
                Settings.AppContext.Tap(loc);
                Settings.AppContext.WaitForElement(pkLocationsQuery);
                Assert.AreEqual(loc, Settings.AppContext.Query(pkLocationsQuery)[0].Text, "View this screenshot to verify that the location selected was LKQ Dominion");
                Console.WriteLine("View this screenshot to verify that the location selected was: " + loc);
                Settings.AppContext.Screenshot("Verify that the location selected was: " + loc);
                location = loc;
                TapBtnDone();
                //SetPreferredLocation();
            }
            else
            {
                Console.WriteLine("Location already set");
                Settings.AppContext.Screenshot("Location already set");
            }
        }

        public bool IsLocationSet()
        {
            
            if (Settings.AppContext.Query(c=>c.Marked("lblWelcome")).Count()>=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetPreferredLocation()
        {
            string loc = location;
            
            TapBtnDone();
        }

        //SRP Methods
        public void TapBtnDone()
        {
            Settings.AppContext.Tap(btnDoneQuery);
        }

        public void TapEditText()
        {
            Settings.AppContext.Tap(pkLocationsQuery);
        }
    }
}
