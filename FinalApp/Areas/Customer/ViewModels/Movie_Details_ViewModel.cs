using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApp.Areas.Customer.ViewModels
{
    public class Movie_Details_ViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Movie> RelatedMovies  { get; set; }
    }
}