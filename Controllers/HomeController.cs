using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Models;

namespace TrainTracker.Controllers {
    public class HomeController : Controller {
        [HttpGet ("")]
        public IActionResult Index () {

            return View ();
        }

        [HttpGet ("Dashboard")]
        public IActionResult Dashboard () {
            return View ();
        }

        [HttpGet ("Tips")]
        public IActionResult Tips () {
            return View ();
        }

        [HttpGet]
        [Route("/map")]
        public IActionResult Map()
        {
            return View();
        }

    }
}