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
    public class SettingsScreenObjectRepository : BasePageObjectRepository
    {
        public static IApp app;
        public int seconds = 30;
        public AppResult[] results;
        public Query btnHamburgerQuery;
        public Query lblPreferredLocationQuery;
        public Query pkPreferredLocationQuery;
        public Query lblDefaultSearchQuery;
        public Query pkDefaultSearchQuery;
        public Query lblNotifClearanceQuery;
        public Query swcNotifClearanceQuery;
        public Query lblNotifNewVehQuery;
        public Query swcNotifNewVehQuery;

        public SettingsScreenObjectRepository(IApp app) : base(app)
        { InitializeVariables(); }

        public void InitialLoadSettings()
        {
            App.WaitForElement(c => c.Marked("lblPreferredLocation"), timeout: wait);
            App.Screenshot("Verified that the Preferred Location Label exists");
            App.WaitForElement(c => c.Marked("pkPreferredLocation"), timeout: wait);
            App.Screenshot("Verified that the Preferred Location picker exists");
            App.WaitForElement(c => c.Marked("lblDefaultSearch"), timeout: wait);
            App.Screenshot("Verified that the Default Search label exists");
            App.WaitForElement(c => c.Marked("lblNotifClearance"), timeout: wait);
            App.Screenshot("Verified that the Clearance Notification label exists");
            App.WaitForElement(c => c.Marked("swcNotifClearance"), timeout: wait);
            App.Screenshot("Verified that the Clearance Notification switch exists");
            App.WaitForElement(c => c.Marked("lblNotifNewVeh"), timeout: wait);
            App.Screenshot("Verified that the New Vehicle Notification label exists");
            App.WaitForElement(c => c.Marked("swcNotifNewVeh"), timeout: wait);
            App.Screenshot("Verified that the New Vehicle Notification switch exists");
        }

        public void InitializeVariables()
        {
            SetWaitTime(seconds);
            btnHamburgerQuery = c => c.Marked("OK");
            lblPreferredLocationQuery = c => c.Marked("lblPreferredLocation");
            pkPreferredLocationQuery = c => c.Marked("pkPreferredLocation");
            lblDefaultSearchQuery = c => c.Marked("lblDefaultSearch");
            pkDefaultSearchQuery = c => c.Marked("pkDefaultSearch");
            lblNotifClearanceQuery = c => c.Marked("lblNotifClearance");
            swcNotifClearanceQuery = c => c.Marked("swcNotifClearance");//text = OFF or ON
            lblNotifNewVehQuery = c => c.Marked("lblNotifNewVeh");
            swcNotifNewVehQuery = c => c.Marked("swcNotifNewVeh");//text = OFF or ON
        }
    }
}