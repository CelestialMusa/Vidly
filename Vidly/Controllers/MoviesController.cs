using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

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
        //GET: Movies/Random
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult New()
        {
            var genreTypes = _dbContext.GenreTypes.ToList();

            var viewModel = new MovieFormViewModel()
            {
                GenreTypes = genreTypes
            };

            return View("MovieForm", viewModel);
        }

        [Route("Movies/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var movie = _dbContext.Movies.Single(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                GenreTypes = _dbContext.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.GenreType = _dbContext.GenreTypes.Single(g => g.Id == movie.GenreType.Id);
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var editedMovie = _dbContext.Movies.Include(m => m.GenreType).Single(c => c.Id == movie.Id);

                editedMovie.Name = movie.Name;
                editedMovie.ReleaseDate = movie.ReleaseDate;
                editedMovie.GenreType = _dbContext.GenreTypes.Single(g => g.Id == editedMovie.GenreType.Id);
                editedMovie.NumberInStock = movie.NumberInStock;
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}