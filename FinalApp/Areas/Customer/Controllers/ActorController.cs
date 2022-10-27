using Entities;
using FinalApp.Areas.Customer.ViewModels;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Areas.Customer.Controllers
{
    
    public class ActorController : Controller
    {

        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public ActorController()
        {
            unit = new UnitOfWork(db);
        }
        // GET: Customer/Actor
        public ActionResult Index(string genresSearch, string countriesSearch, int? decadesSearch, string sortOptions)
        {
            var actors = unit.Actors.GetAll().OrderBy(x => x.FirstName);
            IEnumerable<Actor> filteredActors = actors.ToList();


            //Filtering
            if (!string.IsNullOrEmpty(genresSearch))
            {
                filteredActors = filteredActors.Where(x => x.Movies.Select(y => y?.Genre?.Kind).Contains(genresSearch));
            }

            if (!string.IsNullOrEmpty(countriesSearch))
            {
                filteredActors = filteredActors.Where(x => x.Country.ToString().Contains(countriesSearch));
            }

            if (!(decadesSearch == null))
            {
                filteredActors = filteredActors.Where(x => x.DateOfBirth.Year >= decadesSearch && x.DateOfBirth.Year < decadesSearch + 10);
            }

            //sorting

            switch (sortOptions)
            {
                case "AlphaAsc": filteredActors = filteredActors.OrderBy(x => x.FirstName).ToList(); break;
                case "AliveAsc": filteredActors = filteredActors.Where(x=>!x.DateOfDeath.HasValue).OrderBy(x => x.FirstName).ToList(); break;
                case "DeadAsc": filteredActors = filteredActors.Where(x => x.DateOfDeath.HasValue).OrderBy(x => x.FirstName).ToList(); break;
                case "YoungestAsc": filteredActors = filteredActors.OrderBy(x => x.Age).ToList(); break;
                case "OldestAsc": filteredActors = filteredActors.OrderByDescending(x => x.Age).ToList(); break;
                case "SalaryAsc": filteredActors = filteredActors.OrderByDescending(x => x.Salary).ToList(); break;
                default: filteredActors = filteredActors.OrderBy(x => x.FirstName).ToList(); break;
            }


            ActorIndexViewModel vm = new ActorIndexViewModel()
            {
                Actors = filteredActors,
                GenresPlayed = actors.SelectMany(x => x.Movies.Select(y => y.Genre != null ? y.Genre.Kind : "No Genre")).Distinct().OrderBy(x => x).ToList(),
                Countries = from actor in actors
                            group actor.Country by actor.Country into y
                            orderby y.Count() descending
                            select y,
                Decades = (from actor in actors
                           group actor by (actor.DateOfBirth.Year / 10 * 10) into decades
                           orderby decades.Key descending
                           select decades).ToList()


            };
            return View(vm);

        }

        public ActionResult Details()
        {
            return View();
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