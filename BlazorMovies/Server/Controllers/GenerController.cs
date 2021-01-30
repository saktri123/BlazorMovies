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
    public class GenerController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public GenerController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Gener gener) {
            
            context.Add(gener);
            await context.SaveChangesAsync();
            return gener.Id;
        }
    }
}
