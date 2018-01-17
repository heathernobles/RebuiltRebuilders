using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace Rebuilders.Pages
{
    public class SearchResultsScreen : BasePage<SearchResultsScreenObjectRepository>
    {
        public SearchResultsScreen(IApp app) : base(app, new SearchResultsScreenObjectRepository(app))
        { }
    }
}
