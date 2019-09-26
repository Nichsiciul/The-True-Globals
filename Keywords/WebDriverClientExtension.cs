using SeleniumClient;
using System;

namespace Keywords.KeywordHelper
{
    public static class WebDriverClientExtension
    {
        public static void GoRelativeToHostUrl(this WebDriverClient client, string relativePath)
        {
            //var currentURI = new Uri(client.GetCurrentUrl());
            //var completeURL = currentURI.Scheme + "://" + currentURI.Host + relativePath;
            //client.Go(completeURL);
        } 
    }
}
