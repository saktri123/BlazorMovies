using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositories
{
    public interface IMovieRepository
    {
        Task<int> CreateMovie(Movie movie);
    }
    public class MovieRepostiory : IMovieRepository
    {
        private readonly IHttpService httpService;
        private string url;
        public MovieRepostiory(IHttpService httpService)
        {
            this.httpService = httpService;
            url = "api/Movie";
        }

        public async Task<int> CreateMovie(Movie movie)
        {
            var response = await httpService.Post<Movie, int>(url, movie);
            if (!response.Success)
            {
                throw new Exception(await response.GetBody());
            }
            return response.Response;
        }
    }
}
