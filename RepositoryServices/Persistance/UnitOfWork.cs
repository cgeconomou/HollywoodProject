using MyDatabase;
using RepositoryServices.Core;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            Movies = new MovieRepository(context);
            Genres = new GenreRepository(context);
            Photos = new PhotoRepository(context);
            Actors = new ActorRepository(context);
            Directors = new DirectorRepository(context);
            Students = new StudentRepository(context);
            Persons = new PersonRepository(context);
            Products = new ProductRepository(context);
            Shops = new ShopRepository(context);
        }

        public IMovieRepository Movies { get; private set; }

        public IGenreRepository Genres { get; private set; }

        public IPhotoRepository Photos { get; private set; }

        public IActorRepository Actors { get; private set; }

        public IDirectorRepository Directors { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IPersonRepository Persons { get; private set; }
        public IProductRepository Products { get; private set; }
        public IShopRepository Shops { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
