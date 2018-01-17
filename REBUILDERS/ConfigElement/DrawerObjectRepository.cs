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
        public int seconds = 30;
        public AppResult[] results;
        public string location;
        public Query btnSavedSearchesQuery;
        public Query btnSearchQuery;
        public Query lblYearMakeModelQuery;
        public Query lblMileageQuery;
        public Query lblFileNumberQuery;
        public Query lblValueQuery;
        public Query lblClearanceQuery;
        public Query lblLocationQuery;
        public Query lblBrandingQuery;
        public Query imgVehItemQuery;

        public DrawerObjectRepository(IApp app) : base(app)
        { }
    }
}
