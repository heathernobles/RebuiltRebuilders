using Rebuilders;
using Rebuilders.Utils;
using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Rebuilders.Pages
{

    public class LocationsScreen: BasePage
    {
        public Query List = new Query(c => c.Marked("lvLocations"));
        public Query ListLabels = new Query(c => c.Marked("lblLocation"));
        public Query current = new Query(c => c.Marked("swcSelected"));
        public Location loc = new Location();
        //public string Name;
        //public string Selected;


        public LocationsScreen(IApp app):base(Settings.AppContext)
        { }


        public void AddAllLocationsToSearch()
        {
            int i = 0;
            while (i < Settings.AppContext.Query(current).Count())
            {
                loc.Name = Settings.AppContext.Query(ListLabels)[i].Text;
                loc.Selected = Settings.AppContext.Query(this.current)[i].Text;
                //var current = Settings.AppContext.Query(this.current);
                results = Settings.AppContext.Query(c => c.Marked("swcSelected"));
                for (i = 0; i < results.Length; i++)
                {
                    loc.SwitchX = results[i].Rect.CenterX;
                    loc.SwitchY = results[i].Rect.CenterY;
                    Settings.AppContext.TapCoordinates(loc.SwitchX, loc.SwitchY);

                }
                Settings.AppContext.Screenshot(loc.Name);
                Settings.AppContext.Tap("Done");
                i++;
            }
        }
    }
}

public class Location
{
    public Query LocationName = new Query("lblLocation");
    public Query LocationSelected = new Query("swcSelected");
    public string Name;
    public string Selected;
    public float SwitchX;
    public float SwitchY;

    public Location()
    {}

}




