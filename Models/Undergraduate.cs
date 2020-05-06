using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    public class Undergraduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
    }
}
