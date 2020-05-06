using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RITFacultyV1.Models;
using RITFacultyV1.ViewModels;
using RITFacultyV1.Services;

namespace RITFacultyV1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var getAbout = new GetAbout();
            var allAbout = await getAbout.About();
            var aboutViewModel = new AboutViewModel()
            {
                About = allAbout,
                Title = "About iSchool"
            };
            return View(aboutViewModel);
        }

        public async Task<IActionResult> Faculty()
        {
            var getallFaculty = new GetFaculty();
            var allFaculty = await getallFaculty.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var facultyViewModel = new FacultyViewModel()
            {
                Faculty = sortedFaculty.ToList(),
                Title = "iSchool Faculty"
            };
            return View(facultyViewModel);
        }

        public async Task<IActionResult> Degrees()
        {
            //populate it with the api call to undergrad and need to build the view and model
            var getallundergrad = new GetUndergrad();
            var undergrads = await getallundergrad.GetAllDegrees();
            var sortedUgrad = undergrads.OrderBy(f => f.degreeName);
            var getallgrad = new GetGrad();
            var grads = await getallgrad.GetAllDegrees();
            var sortedGrad = grads.OrderBy(f => f.degreeName);
            var degreeViewModel = new ProgramViewModel()
            {
                Undergraduate = sortedUgrad.ToList(),
                Graduate = sortedGrad.ToList(),
                Title = "Our Degree Programs"
            };
            return View(degreeViewModel);
        }

        public async Task<IActionResult> Coop()
        {
            //populate it with the api call to coop table and need to build the view and model
            var getallcoop = new GetCoopInfo();
            var grads = await getallcoop.CoopInfo();
            var sortedCoop = grads.OrderBy(f => f.term);
            var coopViewModel = new CoopViewModel()
            {
                Coop = sortedCoop.ToList(),
                Title = "Students Co-op"
            };
            return View(coopViewModel);
        }

        public async Task<IActionResult> Employment()
        {
            //populate it with the api call to coop table and need to build the view and model
            var getallemploy = new GetEmploymentInfo();
            var employment = await getallemploy.EmploymentInfo();
            var sortedEmployment = employment.OrderBy(f => f.city);
            var employViewModel = new EmploymentViewModel()
            {
                Employment = sortedEmployment.ToList(),
                Title = "Where our students work"
            };
            return View(employViewModel);
        }

        public async Task<IActionResult> Minors()
        {
            //populate it with the api call to ug minors and need to build the view and model
            var getallminors = new GetUgMinors();
            var minors = await getallminors.GetAllUgMinors();
            var sortedMinors = minors.OrderBy(f => f.name);
            var minorViewModel = new UgMinorsViewModel()
            {
                UgMinors = sortedMinors.ToList(),
                Title = "iSchool Minors"
            };
            return View(minorViewModel);
        }

    }
}
