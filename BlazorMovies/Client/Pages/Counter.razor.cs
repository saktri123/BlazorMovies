using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonClass singleton { get; set; }
        [Inject] TransientClass transient { get; set; }
        private int currentCount = 0;
        private void IncrementCount()
        {
            currentCount++;
            singleton.Value++;
            transient.Value++;
        }
        List<Movie> movies;
        protected override void OnInitialized()
        {
            movies = new List<Movie>() {
                new Movie{  Name = "Joker", ReleaseDate = new DateTime(2020, 7, 2)},
                new Movie{  Name = "Avengers", ReleaseDate = new DateTime(2019, 12, 8)},
            };
        }
    }
}
