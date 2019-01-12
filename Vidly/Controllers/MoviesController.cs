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
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sharknado!"};

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            var customers = new List<Customer>()
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 1"}
            };

            var RandomViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(RandomViewModel);
        }

        public ActionResult edit(int id)
        {
            return Content("Id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex ?? 1, String.IsNullOrWhiteSpace(sortBy) ? "Name" : sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4}):range(1970, 2018)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate (int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}