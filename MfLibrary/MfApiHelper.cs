using DtoLibrary.Mf;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace MfLibrary
{
    public static class MfApiHelper
    {
        public static MfSubjectDto SearchNip(string nipNr)
        {
            var client = CreateClient();
            var request = new RestRequest("api/{1}/{2}/{3}", Method.GET);
            request.AddUrlSegment("1", "search");
            request.AddUrlSegment("2", "nip");
            request.AddUrlSegment("3", nipNr);
            request.AddParameter("date", DateTime.Today.ToString("yyyy-MM-dd"));
            var response = client.Execute(request);
            var content = response.Content;
            var mfRoot = JsonConvert.DeserializeObject<MfRootObjectDto>(content);
            return mfRoot?.Result?.Subject;
        }

        //public static string GetNips(List<string> nipNumbers)
        //{
        //    var client = CreateClient();
        //    var request = new RestRequest("api/{1}/{2}/{3}", Method.GET);
        //    request.AddUrlSegment("1", "search");
        //    request.AddUrlSegment("2", "nips");
        //    request.AddUrlSegment("3", string.Join(",", nipNumbers));
        //    request.AddParameter("date", DateTime.Today.ToString("yyyy-MM-dd"));
        //    var response = client.Execute(request);
        //    return response.Content;
        //}

        private static RestClient CreateClient()
        {
            var proxy = WebRequest.DefaultWebProxy;
            proxy.Credentials = CredentialCache.DefaultCredentials;
            var appSettings = ConfigurationManager.AppSettings;
            var apiUrl = appSettings["MfProdUrl"];
            if (string.IsNullOrEmpty(apiUrl))
                apiUrl = appSettings["MfTestUrl"];
            var client = new RestClient(apiUrl)
            {
                Proxy = proxy
            };
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("ContentType", "application/x-www-form-urlencoded");
            client.AddDefaultHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            return client;
        }
    }
}
