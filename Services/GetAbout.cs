using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RITFacultyV1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RITFacultyV1.Services
{
    public class GetAbout
    {
        public async Task<About> About()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/about/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<About>(data);
                    List<About> aboutlist = new List<About>();
                    About abt = new About();
                    abt = rtnResults;
                    return abt;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    About ab = new About();
                    return ab;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    About ab = new About();
                    return ab;
                    //return "Exception"; ;
                }
            }
        }
    }
}
