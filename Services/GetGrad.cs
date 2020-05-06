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
    public class GetGrad
    {
        public async Task<List<Graduate>> GetAllDegrees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/degrees/graduate/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data1 = response.Content;
                    var data = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Graduate>>>(data);
                    List<Graduate> gradList = new List<Graduate>();
                    Graduate undergraduate = new Graduate();

                    foreach (KeyValuePair<string, List<Graduate>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            gradList.Add(item);
                        }
                    }
                    return gradList;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Graduate> gradMajorsList = new List<Graduate>();
                    return gradMajorsList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Graduate> gradMajorsList = new List<Graduate>();
                    return gradMajorsList;
                }
            }
        }
    }
}
