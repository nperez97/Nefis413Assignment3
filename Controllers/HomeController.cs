using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nefis413Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nefis413Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(AddMovie oNewMovie)
        {
            Repository.AddResponse(oNewMovie);

            if (ModelState.IsValid) //check the field inputs if they are valid
            {
                Response.Redirect("Movies"); // if submission is taken, this will take info and show the add movie page with fields cleared
            }

            return View("Movies", oNewMovie);
        }

        public IActionResult ViewMovies()
        {
            return View(Repository.Responses.Where(movie => movie.Title != "Independence Day"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
