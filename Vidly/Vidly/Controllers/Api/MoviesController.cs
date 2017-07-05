using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        //Get /api/movies/1
        public MovieDto GetMovie(int id) 
        {
            var movie = _context.Movies.SingleOrDefault(c => c.ID == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movie.DateAdded = DateTime.Now;
            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //Get /api/movies/1
        [HttpPost]
        public IHttpActionResult CreateMovie(int id, MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(moviedto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviedto.ID =movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), moviedto);
        }
        // Put /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c=> c.ID==id);
            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            Mapper.Map(moviedto, movieInDb);
            _context.SaveChanges();

        }
        // Delete /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }



    }
}
