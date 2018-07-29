using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeASPNETCORE.Models;
using PracticeASPNETCORE.Services;
using PracticeASPNETCORE.ViewModels;

namespace PracticeASPNETCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentService _studentService;

        public HomeController(StudentService sService)
        {
            this._studentService = sService;
        }

        public IActionResult Index()
        {
            ViewBag.Search = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int top)
        {
            var resultTuple = _studentService.GetStudents(top);
            ViewBag.LessThanRequested = resultTuple.Item1;
            ViewBag.Search = true;
            ViewBag.Count = resultTuple.Item3;
            return View(new HomeViewModel { Students = resultTuple.Item2 });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
