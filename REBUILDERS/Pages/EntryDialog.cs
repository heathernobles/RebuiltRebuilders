using System.Linq;
using Rebuilders.Utils;
using Xamarin.UITest;

namespace Rebuilders.Pages
{
    public class EntryDialog:BasePage
    {
        public Query Title { get; } = new Query(c => c.Marked("alertTitle"));
        public Query Entry { get; } = new Query(c => c.Marked("editText_dialog"));
        public Query AcceptButton { get; } = new Query(c => c.Marked("button1"));
        public Query CancelButton { get; } = new Query(c => c.Marked("button2"));

        public EntryDialog(IApp app): base(app)
        { }

        public void WaitToAppear()
        {
            Settings.AppContext.WaitForElement(Title);
        }

        public string GetEntryText()
        {
            var entry = Settings.AppContext.Query(Entry).FirstOrDefault();
            return entry?.Text;
        }

        public void TapAcceptButton()
        {
            Settings.AppContext.Tap(AcceptButton);
        }

        public void TapCancelButton()
        {
            Settings.AppContext.Tap(CancelButton);
        }
    }
}
