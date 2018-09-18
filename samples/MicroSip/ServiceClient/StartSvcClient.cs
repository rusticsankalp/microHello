using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{

    public class StartRecord
    {
        public int ID { get; set; }
        public int Value { get; set; }
    }
    class StartSvcClient
    {
        private HttpClient client = null;
        public StartSvcClient(string baseAddress)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<StartRecord> GetStartRecordAsync(int id)
        {
            StartRecord rec = null;
            HttpResponseMessage response = await client.GetAsync($"api/StartRecords/{id}");
            if(response.IsSuccessStatusCode)
            {
                rec = await response.Content.ReadAsAsync<StartRecord>();
            }

            return rec;
        }

        public async Task<StartRecord> CreateStartRecordAsync(StartRecord stRec)
        {

            StartRecord rec = null;
            HttpResponseMessage response = await client.PostAsJsonAsync(
           "api/StartRecords", stRec);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            //return response.Headers.Location;\
            if (response.IsSuccessStatusCode)
            {
                rec = await response.Content.ReadAsAsync<StartRecord>();
            }
            return rec;

        }

        //public async Task<StartRecord> CreateStartRecordAsync(StartRecord stRec)
        //{

        //    StartRecord rec = null;
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //   "api/StartRecords", stRec);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    //return response.Headers.Location;\
        //    if (response.IsSuccessStatusCode)
        //    {
        //        rec = await response.Content.ReadAsAsync<StartRecord>();
        //    }
        //    return rec;

        //}
    }
}
