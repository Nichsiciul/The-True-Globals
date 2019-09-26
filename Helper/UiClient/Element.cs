using System;
using System.Drawing;

namespace UiClient
{
    public interface Element<T>
    {
        // Element state
        bool IsSelected();

        String GetAttribute(String attributeName);

        String GetText();

        String GetElementType();

        bool IsEnabled();


        bool IsDisplayed();

        // Element interaction
        void Click();

        void DoubleClick();

        void Clear();

        void Check();

        void SendKeys(String keys);

        void SetText(String text);

        Bitmap TakeScreenshot();

        void SelectDropdown(String visibleText);

        Element<T> GetChild(T locator);

        bool EnsureVisible();

        bool Focus();
    }
}
