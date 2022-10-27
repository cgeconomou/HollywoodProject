using Entities;
using FinalApp.Areas.Customer.ViewModels;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Areas.Customer.Controllers
{
    public class MovieController : Controller
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public MovieController()
        {
            unit = new UnitOfWork(db);
        }

        // GET: Customer/Movie
        public ActionResult Index()
        {
            MovieIndexViewModel vm = new MovieIndexViewModel()
            {
                BestMovies = unit.Movies.GetBestMovies(),
                LongestMovies = unit.Movies.GetLongestMovies(),
                OldestMovies = unit.Movies.GetOldestMovies(),
                Top5AdventureMovies = unit.Movies.GetTopMoviesByGenre("Adventure", 5),
                Top5DramaMovies = unit.Movies.GetTopMoviesByGenre("Drama", 5),
            };


            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = unit.Movies.GetById(id);

            if (movie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var relatedMovies = unit.Movies.GetRelatedMovies(id);

            Movie_Details_ViewModel vm = new Movie_Details_ViewModel()
            {

                Movie = movie,
                RelatedMovies = relatedMovies

            };


            return View(vm);
        }

        [ChildActionOnly]
        public ActionResult DisplayMovieCards(List<Movie> movies, string headerMessage)
        {
            DisplayMovieCardsViewModel vm = new DisplayMovieCardsViewModel()
            {
                Movies = movies,
                HeaderTitle = headerMessage
            };
            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}