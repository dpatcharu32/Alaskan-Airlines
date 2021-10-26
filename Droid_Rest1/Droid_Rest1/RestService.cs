using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FlightScheduleApp.Models;
using Newtonsoft.Json;

namespace FlightScheduleApp.Helpers
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "8420dcb1d57f4c13b47b18a4faf0d990");
        }

        public async Task<APIResponse> GetDataAsync(string Origin, string Destination, DateTime DatePicker)
        {
            APIResponse apiresponse = null;
        

            string endpoint = "https://apis.qa.alaskaair.com/aag/1/guestServices/flights/?fromDate=" + DatePicker.ToString("yyyy-MM-dd") +
                "&toDate=" + DatePicker.ToString("yyyy-MM-dd") + "&origin=" + Origin + "&destination=" + Destination + "&nonStopOnly=false";

            Uri uri = new Uri(string.Format(endpoint, string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);  
            if (response.IsSuccessStatusCode)
            {
                string returnresp = await response.Content.ReadAsStringAsync();
                apiresponse = JsonConvert.DeserializeObject<APIResponse>(returnresp);
            }

            return apiresponse;
        }


    }


}
