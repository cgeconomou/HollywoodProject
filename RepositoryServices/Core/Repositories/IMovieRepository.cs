using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Core.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IEnumerable<Movie> GetMoviesOrderByAscending();
        IEnumerable<Movie> GetBestMovies();
        IEnumerable<Movie> GetTopMoviesByGenre(string genre,int count);
        IEnumerable<Movie> GetLongestMovies();
        IEnumerable<Movie> GetOldestMovies();
        IEnumerable<Movie> GetRelatedMovies(int? id);
        
    }
}

