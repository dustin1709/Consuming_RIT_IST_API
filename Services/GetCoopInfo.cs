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
    public class GetCoopInfo
    {
        public async Task<List<Coop>> CoopInfo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/employment/coopTable/coopInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Coop>>>(data);
                    List<Coop> coopTable = new List<Coop>();
                    Coop coop = new Coop();

                    foreach (KeyValuePair<string, List<Coop>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            coopTable.Add(item);
                        }
                    }
                    return coopTable;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Coop> coopList = new List<Coop>();
                    return coopList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Coop> coopList = new List<Coop>();
                    return coopList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
