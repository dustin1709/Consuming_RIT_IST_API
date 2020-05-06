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
    public class GetUgMinors
    {
        public async Task<List<UgMinors>> GetAllUgMinors()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/minors/UgMinors/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data1 = response.Content;
                    var data = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<UgMinors>>>(data);
                    List<UgMinors> minorList = new List<UgMinors>();
                    UgMinors minor = new UgMinors();

                    foreach (KeyValuePair<string, List<UgMinors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            minorList.Add(item);
                        }
                    }
                    return minorList;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<UgMinors> underGradMinorList = new List<UgMinors>();
                    return underGradMinorList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<UgMinors> underGradMinorList = new List<UgMinors>();
                    return underGradMinorList;
                }
            }
        }
    }
}
