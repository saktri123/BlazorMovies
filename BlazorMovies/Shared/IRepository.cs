using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMovies.Shared
{
    public interface IRepository
    {
        public List<Movie> GetMovies();
    }
}
