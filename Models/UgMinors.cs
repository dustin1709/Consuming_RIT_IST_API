using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RITFacultyV1.Models
{
    public class UgMinors
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> courses { get; set; }
        public string note { get; set; }
    }
}
