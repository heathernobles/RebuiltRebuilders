using Rebuilders.Utils;
using Xamarin.UITest;

namespace Rebuilders.Pages
{
    public class Drawer : BasePage
    {
        public Query DrawerButton { get; }

        public Drawer(IApp app) : base(app)
        {
            DrawerButton = new Query(c => c.Marked("OK"));           
        }

        public void InitialLoadDrawer()
        {
            Settings.AppContext.Tap(DrawerButton);
            Settings.AppContext.WaitForElement(c => c.Marked("Home"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Home item exists");
            Settings.AppContext.WaitForElement(c => c.Marked("Search"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Search item exists");
            Settings.AppContext.WaitForElement(c => c.Marked("Saved Searches"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Saved Searches item exists");
            Settings.AppContext.WaitForElement(c => c.Marked("Settings"), timeout: wait);
            Settings.AppContext.Screenshot("Verified that the Settings item exists");
        }

        public Query GetMenuItem(string text)
        {
            return new Query(c => c.Marked("lblMenuItem").Text(text));
        }

        public void NavigateTo(string itemText)
        {
            Settings.AppContext.WaitForElement(DrawerButton);
            Settings.AppContext.Tap(DrawerButton);
            Settings.AppContext.Screenshot("Opening the drawer menu...");

            var menuItem = GetMenuItem(itemText);
            Settings.AppContext.WaitForElement(menuItem);
            Settings.AppContext.Tap(menuItem);
        }

        public void OpenDrawer()
        {
            Settings.AppContext.Tap(DrawerButton);
        }

        public SettingsScreen TapSettings()
        {
            Settings.AppContext.Tap(DrawerButton);
            SettingsScreen settings = new SettingsScreen(Settings.AppContext);
            return settings;
        }
    }
}