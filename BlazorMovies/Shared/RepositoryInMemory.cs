using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMovies.Shared
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>() {
            new Movie{  Name = "Spider Man: Far from home.", ReleaseDate = new DateTime(2020, 7, 2)},
            new Movie{  Name = "Gravity", ReleaseDate = new DateTime(2019, 12, 8)},
            new Movie{  Name = "Noha", ReleaseDate = new DateTime(2008, 2, 10)},
        };
        }
    }
}
