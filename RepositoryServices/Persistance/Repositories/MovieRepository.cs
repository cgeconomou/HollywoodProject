using Entities;
using MyDatabase;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices.Persistance.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {

        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Movie> GetBestMovies()
        {
            return table.OrderBy(x => x.Rating).Take(10).ToList();
        }

        public IEnumerable<Movie> GetMoviesOrderByAscending()
        {
            return table.OrderBy(x => x.Title).ToList();
        }

        public IEnumerable<Movie> GetLongestMovies()
        {
            return table.OrderBy(x => x.Duration).Take(10).ToList();
        }

        public IEnumerable<Movie> GetOldestMovies()
        {
            return table.OrderBy(x => x.ProductionYear).Take(10).ToList();
        }
        //("Adventure", 10)   
        public IEnumerable<Movie> GetTopMoviesByGenre(string genre, int count)
        {
            return table.Where(x => x.Genre.Kind == genre).OrderByDescending(x => x.Rating).Take(count).ToList();
        }

        public IEnumerable<Movie> GetRelatedMovies(int? id)
        {
            var movie = table.Find(id);
            //
            var relatedMovies = table.Where(x => x.Genre.Kind == movie.Genre.Kind && x.MovieId != movie.MovieId).ToList();
            return relatedMovies;
        }
    }
}
