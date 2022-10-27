using Entities;
using MyDatabase;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IQueryable<IGrouping<Country, Actor>> GetActorsGroupedByCountry()
        {
            var groups = from actor in table
                         group actor by actor.Country into lista
                         select lista;

            return groups;

        }

        
    }
}
