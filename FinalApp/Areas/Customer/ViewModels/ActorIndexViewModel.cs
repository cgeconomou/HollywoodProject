using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApp.Areas.Customer.ViewModels
{
    public class ActorIndexViewModel
    {
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<IGrouping<Country, Country>> Countries { get; set; }
        public IEnumerable<IGrouping<int, Actor>> Decades { get; set; }
        public IEnumerable<string> GenresPlayed { get; set; }


    }
}