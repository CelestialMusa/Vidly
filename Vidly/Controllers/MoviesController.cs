using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Movies/Random
        public ActionResult Index()
        {
            //var movies = _dbContext.Movi

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            var movies = _dbContext.Movies.Include(c => c.GenreType).ToList();

            return View(movies);
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

        [Route("Movies/MovieDetails/{Id:regex(\\d)}")]
        public ActionResult MovieDetails(int Id)
        {
            var movie = _dbContext.Movies.Include(c => c.GenreType).SingleOrDefault(c => c.Id == Id);

            return View(movie);
        }
    }
}