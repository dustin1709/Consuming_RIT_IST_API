using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    public class Graduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public IList<string> concentrations { get; set; }
        public IList<string> availableCertificates { get; set; }
    }
}
