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
        List<Movie> movies = new List<Movie>
            {
                new Movie {Id =1, Name = "Shrek !"},
                new Movie {Id = 2, Name = "Die Hard"}
            };

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "shrek!"};
            // return View(movie);
            //return Content("Hello world");
            //return HttpNotFound();
            //return  new EmptyResult();
            // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
           // ViewData["Movie"] = movie;


           var customers = new List<Customer>
           {
               new Customer{Name = "Customer 1"},
               new Customer{Name = "Customer 2"}
           };

           var viewModel = new RandomMovieViewModel
           {
               Movie = movie,
               Customers = customers
           };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Index()
        {
            
            var movieCollectionViewModel = new MoviesCollectionViewModel()
            {
                Movies = movies
            };

            return View(movieCollectionViewModel);
        }

        [Route("movies/detail/{id}")]
        public ActionResult Detail(int id)
        {
            var movie = movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                //return HttpNotFound();
                return Content("the movie is not in our db.");
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" +month);
        }

    }
}