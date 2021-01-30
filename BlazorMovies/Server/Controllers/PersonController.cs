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

        public PersonController(ApplicationDBContext context)
        {
            this.Context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person) {
            Context.Add(person);
            await Context.SaveChangesAsync();
            return person.Id;
        }
    }
}
