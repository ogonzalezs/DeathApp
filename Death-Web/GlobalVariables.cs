using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Death_Web
{
    public static class GlobalVariables
    {
        public static HttpClient DeathApiClient = new HttpClient();

        static GlobalVariables()
        {
            DeathApiClient.BaseAddress = new Uri("http://localhost:51196/api/");
            DeathApiClient.DefaultRequestHeaders.Clear();
            DeathApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}