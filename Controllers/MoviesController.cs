using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
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
             var moviesVM = new MoviesCollectionViewModel
            {
                Movies = _context.Movies.Include(c => c.Genere).ToList()
            };
            

            return View(moviesVM);
        }

        [Route("movies/details/{id}")]
        public ActionResult Detail(int id)
        {
            var moviesVM = new MoviesCollectionViewModel
            {
                Movies = _context.Movies.ToList()
            };

            var movie = moviesVM.Movies.SingleOrDefault(x => x.Id == id);
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