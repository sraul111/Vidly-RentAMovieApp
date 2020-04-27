﻿using System;
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

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format($"pageIndex={pageIndex}&sortBy={sortBy}"));
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" +month);
        }

    }
}