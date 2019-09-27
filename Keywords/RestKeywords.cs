using Microsoft.Rest;
using RestSharp;
using System;
using System.Net;

namespace Keywords
{
   public class RestKeywords
    {
        public RestKeywords(RestClient restClient)
        {
            client = restClient;
            if (restClient == null)
            {
                client = new RestClient { BaseUrl = new Uri("http://www.google.com"), PreAuthenticate = false };
            }
        }

        private RestClient client { get; set; }
        private string token;

        public RestRequest GetRequest(string rescource, Method method)
        {
            var request = new RestRequest(rescource, method) { RequestFormat = DataFormat.Json };
            var username = "testuser1";
            var password = "password1";
            token = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.AddParameter("Authorization", string.Format($"Basic {token}"), ParameterType.HttpHeader);
            return request;
        }

        public IRestResponse Execute(IRestRequest request)
        {
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return response;
            }
            if(response.StatusCode < HttpStatusCode.OK || response.StatusCode >= HttpStatusCode.BadRequest)
            {
                throw new RestException($"[Rest] Calling {response.ResponseUri} an error occured: {response.StatusCode} - {response.Content}");
            }

            return response;
        }

        #region General
        public HttpStatusCode GetPage(string uri)
        {
            var request = GetRequest(uri, Method.GET);
            var response = Execute(request);
            return response.StatusCode;
        }
        #endregion
    }
}
