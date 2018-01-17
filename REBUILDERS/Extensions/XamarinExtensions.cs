using MobileFramework.Base;


namespace MobileFramework.Extension
{
    public static class XamarinExtensions
    {
        public static void ClearAndEnterText(this Query element, string text)
        {
            ClearText(element);
            EnterText(element, text);
        }

        public static void ClearText(this Query element)
        {
            BasePage.ApplicationContext.ClearText(element);
        }

        public static void Click(this Query element)
        {
            BasePage.ApplicationContext.Tap(element);
        }

        public static void DismissKeyboard()
        {
            BasePage.ApplicationContext.DismissKeyboard();
        }

        public static void EnterText(this Query element, string text)
        {
            BasePage.ApplicationContext.EnterText(text);
        }

        public static void EnterTextWithDismissKeyboard(this Query element, string text)
        {
            ClearAndEnterText(element,text);
            DismissKeyboard();
        }

        
        public static void Screenshot(this Query element, string title)
        {
            BasePage.ApplicationContext.Screenshot(title);
        }

        public static void WaitForElement(this Query element)
        {
            BasePage.ApplicationContext.WaitForElement(element, "Element not found");
        }
    }
}
