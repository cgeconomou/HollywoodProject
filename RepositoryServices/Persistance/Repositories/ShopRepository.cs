using Entities;
using MyDatabase;
using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    internal class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
