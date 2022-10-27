using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApp.Areas.Customer.ViewModels
{
    public class DisplayMovieCardsViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public string HeaderTitle { get; set; }
    }
}