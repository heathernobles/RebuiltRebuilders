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
    public class Drawer : BasePage<DrawerObjectRepository>
    {
        public Drawer(IApp app) : base(app, new DrawerObjectRepository(app))
        { }
        public class DrawerObjectRepository : BasePageObjectRepository
        {
            public static IApp app;
            public int seconds = 30;
            public string locationH;
            public AppResult[] results;
            public Query lblWelcomeQuery;
            public Query lblPreferredLocationQuery;
            public Query lblPreferredLocationDescriptionQuery;
            public Query pkLocationsQuery;
            public Query btnDoneQuery;


            public DrawerObjectRepository(IApp app) : base(app)
            { }

        }
    }
}
