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
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDBContext Context;
        private readonly IFileStorageServices fileStorageServices;

        public PersonController(ApplicationDBContext context,IFileStorageServices fileStorageServices)
        {
            this.Context = context;
            this.fileStorageServices = fileStorageServices;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person) {
            if (!string.IsNullOrWhiteSpace(person.Picture)){
                var personImage = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorageServices.SaveFile(personImage, "jpg", "People");
            }
            Context.Add(person);
            await Context.SaveChangesAsync();
            return person.Id;
        }
    }
}
