using Rebuilders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;


namespace Rebuilders
{
    public class Settings
    {
        public static IApp AppContext { get; set; }

        public static string Path = "../../intouchqc.apk";

        public Settings()
        {
            AppContext = ConfigureApp
                .Android
                .ApkFile(Path)
                .EnableLocalScreenshots()
                .StartApp(Xamarin.UITest.Configuration.AppDataMode.Auto);
        }

        public static void SelectItem(string i)
        {
            AppContext.Tap(i);
        }

        public static void ClickButton(Query btn)
        {
            AppContext.Tap(btn);
        }

        /*[Export("BackdoorExit")]
        public void BackdoorExit()
        {
            AppContext.Back();
        }*/

    }
}
