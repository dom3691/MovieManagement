using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.Interface;
using MovieManagement.Model;

namespace MovieManagement.Service
{
    public class MovieService : IMovieService
    {
        private readonly ApplcationDbContext _context;

        public MovieService(ApplcationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovie(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                throw new ArgumentException("Invalid movie ID.");
            }

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new ArgumentException("Invalid movie ID.");
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
