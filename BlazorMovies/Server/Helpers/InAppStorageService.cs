using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Helpers
{
    public class InAppStorageService : IFileStorageServices
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InAppStorageService(IWebHostEnvironment env,IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string fileRoute, string containerName)
        {
            var fileName = Path.GetFileName(fileRoute);
            var fileDrectory = Path.Combine(env.WebRootPath, containerName, fileName);
            if (File.Exists(fileDrectory)) {
                File.Delete(fileDrectory);
            }
            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute)
        {
            if (!string.IsNullOrEmpty(fileRoute)) {
                await DeleteFile(fileRoute, containerName);
            }
            return await SaveFile(content, extension, containerName);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string containerName)
        {
            var filename = $"{Guid.NewGuid()}.{ extension}";
            string folder = Path.Combine(env.WebRootPath, containerName);
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            string savingpath = Path.Combine(folder, filename);
            await File.WriteAllBytesAsync(savingpath, content);
            var currentURL = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var pathForDatabase = Path.Combine(currentURL, containerName, filename);
            return pathForDatabase;
        }
    }
}
