using System;
using System.Drawing;

namespace UiClient
{
    public interface Window
    {
        void Close();

        String GetTitle();

        void Maximize();

        void Fullscreen();

        Dimension GetSize();

        void SetSize(Dimension size);

        Bitmap TakeScreenshot();
    }
}
