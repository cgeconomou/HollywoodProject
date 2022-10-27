using Entities;
using MyDatabase;
using RepositoryServices;
using RepositoryServices.Core;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            //var objects = db.Movies.ToList()
            //    .Select(x => new
            //    {
            //        titlos = x.Title,
            //        bathmos = x.Rating,
            //        skinothetis = new { onoma = x.Director.FirstName, epitheto = x.Director.LastName },
            //        ithopoioi = x.Actors
            //        .Select(y => new
            //        {
            //            onoma = y.FirstName,
            //            epitheto = y.LastName
            //        }),
            //        missingRating = 10 - x.Rating,
            //        years = DateTime.Now.Year - x.ProductionYear.Year
            //    });


            //foreach (var item in objects)
            //{
            //    Console.WriteLine(item.years);
            //}

            ////Querry

            //var objects3 = from movie in db.Movies.ToList()
            //               select new
            //               {
            //                   titlos = movie.Title,
            //               };


            //Groups
            var tainies = db.Movies.ToList();

            var groups = from movie in tainies
                         group movie by movie.DirectorId into lista
                         select new
                         {
                             onoma = tainies.FirstOrDefault(x => x.DirectorId == lista.Key).Director.FirstName,
                             movies = lista.Select(x => new { x.Title })
                         };



            foreach (var item in groups)
            {
                Console.WriteLine(item.onoma);
                foreach (var movie in item.movies)
                {
                    Console.WriteLine("\t\t" + movie.Title);
                }
            }

        }
    }
}
