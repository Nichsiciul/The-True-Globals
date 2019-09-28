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
                client = new RestClient ( "https://autothon-nagarro-backend-e00.azurewebsites.net");
            }
        }

        private RestClient client { get; set; }
        private string token;

        public RestRequest GetRequest(string rescource, Method method)
        {
            var request = new RestRequest(rescource, method);
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
        public String GetPage(string uri)
        {
            var request = GetRequest(uri, Method.GET);
            var response = Execute(request);
            if(HttpStatusCode.OK.Equals(response.StatusCode))
            {
                return response.Content;
            }
            return null;
            }
        #endregion

        public String PostPage(string uri, Object body, String userId)
        {
            var request = GetRequest(uri, Method.POST);
            request.AddJsonBody(body);
            if(userId != null)
            {
                request.AddHeader("user", userId);
            }
            var response = Execute(request);
            if(response.StatusCode.Equals(HttpStatusCode.OK))
            {
                return response.Content;
            }

            return null;
        }
    }
}
