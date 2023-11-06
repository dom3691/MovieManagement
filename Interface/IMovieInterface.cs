﻿using MovieManagement.Model;

namespace MovieManagement.Interface
{
    public interface IMovieInterface
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task UpdateMovie(int id, Movie movie);
        Task DeleteMovie(int id);
    }
}
