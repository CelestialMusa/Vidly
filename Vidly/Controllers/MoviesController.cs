using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Sharknado!"};

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            var movies = new List<Movie>
            {
                new Movie() { Id = 1,Name = "Sharknado!"},
                new Movie() { Id = 2,Name = "Matrix"},
                new Movie() { Id = 3,Name = "Muppets: Power Rangers"}
            };

            var movieDetails = new MovieDetails()
            {
               Movies = movies
            };

            return View(movieDetails);
        }

        [Route("Movies/Index/{pageIndex}/{sortBy}")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex ?? 1, String.IsNullOrWhiteSpace(sortBy) ? "Name" : sortBy));
        }

        public ActionResult edit(int id)
        {
            return Content("Id=" + id);
        }

        [Route("Movies/Released/{year:regex(\\d{4}):range(1970, 2018)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate (int year, byte month)
        {
            return Content(year + "/" + month);
        }

        [Route("Movies/MovieDetails/{Id:regex(\\d)}/{name}")]
        public ActionResult MovieDetails(int Id,string name)
        {
            var movie = new Movie()
            {
                Id = Id,
                Name = name 
            };

            return View(movie);
        }
    }
}