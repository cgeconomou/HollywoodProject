
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalApp.Controllers
{
    public class HomeController : Controller
    {
        private MyDatabase.ApplicationDbContext hollywoodDb = new MyDatabase.ApplicationDbContext();
        private FinalApp.Models.ApplicationDbContext userDb = new FinalApp.Models.ApplicationDbContext();


        public ActionResult Index()
        {
            return Redirect("/customer/movie/index");
        }

        public ActionResult Method()
        {
            var movies = hollywoodDb.Movies.ToList()
                .Select(x => new
                { 
                    x.Title ,
                    x.Duration,
                    x.Rating,
                    directorFullName = new { x.Director.FirstName, x.Director.LastName }
                }
                );


            return Json(movies, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Index2()
        {
            var orders = hollywoodDb.MovieUserOrders.ToList();

            var movieTitles = from order in orders
                              join movie in hollywoodDb.Movies on order.MovieId equals movie.MovieId
                              //where order.MovieId == movie.MovieId
                              select new { title = movie.Title };


            var orderss = hollywoodDb.MovieUserOrders.ToList();
            var users = userDb.Users.ToList();
            var movies = hollywoodDb.Movies.ToList();
            var res = from order in orders
                      join movie in movies on order.MovieId equals movie.MovieId
                      join user in users on order.UserId equals user.Id
                      where order.MovieId == movie.MovieId
                      select new
                      {
                          title = movie.Title,
                          email = user.UserName,
                          date = order.OrderCompleted.ToString("MM.dd.yyyy")
                      };




            var usernames = from order in orders
                            join user in userDb.Users on order.UserId equals user.Id
                            select new { username = user.UserName };

            var groups = from order in orders
                         group order by order.UserId into lista
                         select lista;

            var groups2 = from order in orders
                          group order by order.UserId into lista
                          select new
                          {
                              email = userDb.Users.Find(lista.Key).Email,
                              movies = lista.Select(x => hollywoodDb.Movies.Find(x.MovieId).Title),
                          };


            return Json(groups2, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}