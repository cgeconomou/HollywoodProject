using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Areas.Admin.Controllers
{
    public class MovieApiController : Controller
    {
        MyDatabase.ApplicationDbContext db = new MyDatabase.ApplicationDbContext();
        UnitOfWork unit;

        public MovieApiController()
        {
            unit = new UnitOfWork(db);
        }



        public ActionResult GetMovies()
        {
            var movies = unit.Movies.GetAll()
                .Select(x => new
                {
                    x.Title,
                    x.PhotoUrl,
                    x.MovieId,
                    ProductionYear = new { day = x.ProductionYear.Day, year = x.ProductionYear.Year , month = x.ProductionYear.Month }
                }
                );
            return Json(new {data= movies}, JsonRequestBehavior.AllowGet);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}