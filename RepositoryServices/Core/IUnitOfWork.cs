using RepositoryServices.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core
{
    internal interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IGenreRepository Genres { get; }
        IPhotoRepository Photos { get; }
        IActorRepository Actors { get; }
        IDirectorRepository Directors { get; }
        IStudentRepository Students { get; }
        IPersonRepository Persons { get; }
        IProductRepository Products { get; }
        IShopRepository Shops { get; }

        int Complete();
    }
}
