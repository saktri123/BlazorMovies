using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IFileStorageServices fileStorageServices;

        public MovieController(ApplicationDBContext context, IFileStorageServices fileStorageServices)
        {
            this.context = context;
            this.fileStorageServices = fileStorageServices;
        }

        [HttpPost]
        public async Task< ActionResult<int>> CreateMovie(Movie movie)
        {
            if (movie.PosterImage != null) {
                var personImage = Convert.FromBase64String(movie.PosterImage);
                movie.PosterImage = await fileStorageServices.SaveFile(personImage, "jpg", "Movie");
            }
            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok(movie.MovieId);
        }
    }
}
