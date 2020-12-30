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
            new Movie{  Name = "Spider Man: Far from home.", 
                ReleaseDate = new DateTime(2020, 7, 2),
                PosterImage = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL__QL50.jpg"
            },
            new Movie{  Name = "Gravity", ReleaseDate = new DateTime(2019, 12, 8),
            PosterImage = "https://m.media-amazon.com/images/M/MV5BNjE5MzYwMzYxMF5BMl5BanBnXkFtZTcwOTk4MTk0OQ@@._V1_UX182_CR0,0,182,268_AL__QL50.jpg"},
            new Movie{  Name = "Noha", ReleaseDate = new DateTime(2008, 2, 10),
            PosterImage = "https://m.media-amazon.com/images/M/MV5BMjAyNzA3ODItNjRhZC00ZTI4LTlkMjAtNzhiNWIyOWY5YTc3XkEyXkFqcGdeQXVyMTE3NjM3NzM1._V1_UY268_CR9,0,182,268_AL__QL50.jpg"},
        };
        }
    }
}
