using Rebuilders.Utils;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Rebuilders.Pages
{
    public class PickerDialog:BasePage
    {
        public Query List { get; } = new Query(c => c.Marked("select_dialog_listview"));
        public Query Items { get; } = new Query(c => c.Marked("text1"));
        public Query DoneButton { get; } = new Query(c => c.Marked("button2"));

        public PickerDialog(IApp app): base(app)
        {
        }

        public void SelectItem(string text)
        {
            Settings.AppContext.WaitForElement(List);
            var item = GetItem(text);
            Settings.AppContext.ScrollDownTo(item, List, ScrollStrategy.Programmatically,timeout:TimeSpan.FromSeconds(30));
            Settings.AppContext.Tap(item);
        }

        public void Close()
        {
            Settings.AppContext.Tap(DoneButton);
        }

        public Query GetItem(string text)
        {
            return new Query(c => c.Marked("text1").Text(text));
        }

        public AppResult[] GetItems()
        {
            Settings.AppContext.WaitForElement(List);
            return Settings.AppContext.Query(Items);
        }

        public void WaitToAppear()
        {
            Settings.AppContext.WaitForElement(List);
        }
    }
}
