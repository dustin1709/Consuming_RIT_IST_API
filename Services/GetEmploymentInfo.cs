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
    public class GetEmploymentInfo
    {
        public async Task<List<Employ>> EmploymentInfo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync("api/employment/employmentTable/professionalEmploymentInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Employ>>>(data);
                    List<Employ> employmentList = new List<Employ>();
                    Employ employer = new Employ();

                    foreach (KeyValuePair<string, List<Employ>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            employmentList.Add(item);
                        }
                    }
                    return employmentList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Employ> employmentList = new List<Employ>();
                    return employmentList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Employ> employmentList = new List<Employ>();
                    return employmentList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
