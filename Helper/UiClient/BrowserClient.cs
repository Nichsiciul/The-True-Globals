using System;

namespace UiClient
{
    public interface BrowserClient<T> : UiClient<T> 
    {
        void Go(String url);

        String GetCurrentUrl();

        void Refresh();

        Object ExecuteScript(String script, params Object[] parameter);

        History History();

        Prompt Prompt();
    }
}
