namespace UiClient
{
    public interface UiClient<T>
    {
        void Quit();

        Window Window();

        Element<T> Element(T locator);
    }
}