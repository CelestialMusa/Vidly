using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }


        // GET /movies/GetCustomers
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movie = _dbContext.Movies.Include(m => m.GenreType).ToList();
               
            var movieDTO = movie.Select(Mapper.Map<Movie, MovieDTO>);

            //return Ok(_dbContext.Movies
            //    .Include(c => c.GenreType)
            //    .ToList().Select(Mapper.Map<Movie, MovieDTO>));

            return Ok(movieDTO);
        }

        [Route("api/movies/DeleteMovie/{Id}")]
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = _dbContext.Movies.Single(m => m.Id == Id);

            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}
