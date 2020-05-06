using System;
using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    public class ProgramViewModel
    {
        public List<Undergraduate> Undergraduate { get; set; }
        public IList<Graduate> Graduate { get; set; }
        public string Title { get; set; }
    }
}
