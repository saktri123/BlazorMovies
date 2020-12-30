using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorMovies.Client.Shared.MainLayout;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonClass singleton { get; set; }
        [Inject] TransientClass transient { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [CascadingParameter] AppState appState { get; set; }

        private int currentCount = 0;
        private static int currentCountStatic = 0;
        IJSObjectReference module;

        [JSInvokable]
        public async void IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert", "Hello Counter");

            currentCount++;
            singleton.Value++;
            transient.Value++;
            currentCountStatic++;
            await js.InvokeVoidAsync("DotNetStaticInvoke");
        }

        private async void IncrementCountJavaScript()
        {
            await js.InvokeVoidAsync("DotNetInstanceInvoke", DotNetObjectReference.Create(this)); 
        }
        [JSInvokable]
        public static Task<int> GetCurrentCount() {
            return Task.FromResult(currentCountStatic);
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
