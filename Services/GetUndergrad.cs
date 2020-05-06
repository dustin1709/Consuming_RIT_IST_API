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
    public class GetUndergrad
    {
        public async Task<List<Undergraduate>> GetAllDegrees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/degrees/undergraduate/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data1 = response.Content;
                    var data = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Undergraduate>>>(data);
                    List<Undergraduate> underGradList = new List<Undergraduate>();
                    Undergraduate undergraduate = new Undergraduate();

                    foreach (KeyValuePair<string, List<Undergraduate>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            underGradList.Add(item);
                        }
                    }
                    return underGradList;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Undergraduate> underGradMajorsList = new List<Undergraduate>();
                    return underGradMajorsList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Undergraduate> underGradMajorsList = new List<Undergraduate>();
                    return underGradMajorsList;
                }
            }
        }
    }
}
