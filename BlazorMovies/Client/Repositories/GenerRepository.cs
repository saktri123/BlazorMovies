using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repositories
{
    public interface IGenerRepository
    {
        Task CreateGener(Gener gener);
    }
    public class GenerRepository : IGenerRepository
    {
        public GenerRepository(IHttpService httpService)
        {
            HttpService = httpService;
        }

        public IHttpService HttpService { get; }
        private string url = "api/gener";

        public async Task CreateGener(Gener gener) {
           var resposne =await this.HttpService.Post(url, gener);
            if (!resposne.Success) {
                throw new ApplicationException(await resposne.GetBody());
            }
            
        }
    }
}
