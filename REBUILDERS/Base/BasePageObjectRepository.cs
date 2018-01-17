using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using NUnit.Core;
using Xamarin.UITest;

namespace Rebuilders.Pages
{
    public class BasePageObjectRepository
    {
        public IApp App;
        public TimeSpan wait;
        public string errTimeout;

        public BasePageObjectRepository(IApp app)
        {
            App = app;
        }
        public void SetWaitTime(int seconds)
        {
            wait = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan GetWaitObj()
        {
            return wait;
        }

        public string GetErrTimeout()
        {
            return errTimeout;
        }

        public void SetErrTimeout()
        {
            errTimeout = "The object took too long to load";
        }

        public void ExitApp()
        {
            Settings.AppContext.Back();
            AppResult[] results;
            bool exited = false;
            results = Settings.AppContext.Query(c => c.All().Property("marked", "button1"));
            if (results.Count() == 0)
            {
                exited = false;
            }
            else
            {
                exited = true;
                Settings.AppContext.Screenshot("Exiting the application...");
            }

            while (exited == false)
            {
                results = Settings.AppContext.Query(c => c.All().Property("marked", "button1"));
                if (results.Count() == 0)
                {
                    Settings.AppContext.Back();
                }
                else if (results.Count() >= 1)
                {
                    exited = true;
                    Settings.AppContext.Screenshot("Exiting the application...");
                }
            }

            DismissDialog();
            return;
        }

        public void DismissDialog()
        {
            Settings.AppContext.Tap(c => c.Id("button1"));
            Settings.AppContext.Screenshot("Application been quit...");
        }
    }
}
