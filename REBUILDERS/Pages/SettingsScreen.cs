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
    public class SettingsScreen : BasePage
    {
        public static IApp app;
        public int seconds = 30;
        public Query btnHamburgerQuery { get; } = new Query(c => c.Marked("lblWelcome"));
        public Query pkPreferredLocationQuery { get; } = new Query(c => c.Marked("pkPreferredLocation"));
        public Query lblDefaultSearchQuery { get; } = new Query(c => c.Marked("lblDefaultSearch"));
        public Query pkDefaultSearchQuery { get; } = new Query(c => c.Marked("pkDefaultSearch"));
        public Query lblNotifClearanceQuery { get; } = new Query(c => c.Marked("lblNotifClearance"));
        public Query swcNotifClearanceQuery { get; } = new Query(c => c.Marked("swcNotifClearance"));
        public Query lblNotifNewVehQuery { get; } = new Query(c => c.Marked("lblNotifNewVeh"));
        public Query swcNotifNewVehQuery { get; } = new Query(c => c.Marked("swcNotifNewVeh"));
        

        public SettingsScreen(IApp app) : base(app)
        { }

        public void InitialLoadSettings()
        {
            //Settings.AppContext.WaitForElement(c => c.Marked("lblPreferredLocation"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Preferred Location Label exists");
            Settings.AppContext.WaitForElement(c => c.Marked("pkPreferredLocation"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Preferred Location picker exists");
            Settings.AppContext.WaitForElement(c => c.Marked("lblDefaultSearch"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Default Search label exists");
            Settings.AppContext.WaitForElement(c => c.Marked("lblNotifClearance"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Clearance Notification label exists");
            Settings.AppContext.WaitForElement(c => c.Marked("swcNotifClearance"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Clearance Notification switch exists");
            Settings.AppContext.WaitForElement(c => c.Marked("lblNotifNewVeh"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the New Vehicle Notification label exists");
            Settings.AppContext.WaitForElement(c => c.Marked("swcNotifNewVeh"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the New Vehicle Notification switch exists");
        }

        public void VerifyDefaultSavedSearchRemoved()
        {

        }


    }
}
