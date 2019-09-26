
namespace UiClient
{
    public interface Prompt
    {
        void DismissAlert();

        void AcceptAlert();

        string GetAlertText();

        void SendAlertText(string keys);

        bool IsDisplayed();
    }
}