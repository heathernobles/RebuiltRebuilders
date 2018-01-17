using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace Rebuilders.Pages
{
    public class HomeScreen: BasePage<HomeScreenObjectRepository>
    {
        public HomeScreen(IApp app): base(app, new HomeScreenObjectRepository(app))
        { }
    }
}
