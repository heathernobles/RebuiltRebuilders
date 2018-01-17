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
using Rebuilders.Utils;
using Xamarin.UITest.Configuration;

namespace Rebuilders.Pages
{
    public class BasePage
    {
        public TimeSpan wait;
        public string errTimeout;
        public AppResult[] results;
        public int Counter;

        public BasePage(IApp app)
        {
            Settings.AppContext = app;
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
            bool exited = false;
            Settings.AppContext.Back();
            AppResult[] results;
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
            Settings.AppContext.Screenshot("Application quit...");
        }

        public void ScrollTo(Query query)
        {
            Settings.AppContext.ScrollDownTo(query);
        }

        public void SetCount(Func<AppQuery, AppQuery> obj)
        {
            results = Settings.AppContext.Query(obj);
            Counter = results.Count();
        }

        public int GetCount(Func<AppQuery, AppQuery> obj)
        {
            results = Settings.AppContext.Query(obj);
            Counter = results.Count();
            return Counter;
        }

        public void StartApp_ClearedCache()
        {
            string path = "../../com.lkqcorp.rebuilders.qc.apk";
            Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp(AppDataMode.Clear);
        }

        public void StartApp_PersistCache()
        {
            string path = "../../com.lkqcorp.rebuilders.qc.apk";
            Settings.AppContext = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp(AppDataMode.DoNotClear);
        }

        public void ConnectApp_PersistCache()
        {
            Settings.AppContext = ConfigureApp.Android.ConnectToApp();
        }
    }
}
