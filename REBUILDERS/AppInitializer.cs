using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Rebuilder
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                string path = "../../com.lkqcorp.rebuilders.qc.apk";
                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .ApkFile(path)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .EnableLocalScreenshots()
                .InstalledApp("../../RebuildersCustomer.iOS.ipa")
                .StartApp();
        }
    }
}

