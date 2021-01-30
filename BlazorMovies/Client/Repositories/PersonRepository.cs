using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
    }
    public class PersonRepository : IPersonRepository
    {
        private readonly IHttpService service;
        private readonly string url = "api/Person";

        public PersonRepository(IHttpService service)
        {
            this.service = service;
        }

        public async Task CreatePerson(Person person) {
            var resposne = await service.Post(url, person);
            if (!resposne.Success) {
                throw new Exception(await resposne.GetBody());
            }
        }
    }
}
