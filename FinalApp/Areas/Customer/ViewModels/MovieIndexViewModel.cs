using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApp.Areas.Customer.ViewModels
{
    public class MovieIndexViewModel
    {
        public IEnumerable<Movie> BestMovies { get; set; }
        public IEnumerable<Movie> Top5DramaMovies { get; set; }
        public IEnumerable<Movie> Top5AdventureMovies { get; set; }
        public IEnumerable<Movie> LongestMovies { get; set; }
        public IEnumerable<Movie> OldestMovies { get; set; }
    }
}