using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TravelHelper.Web.Services.Interfaces;

namespace TravelHelper.Web.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;

        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<string>> UploadAsync(params IFormFile[] files)
        {
            var paths = new List<string>();

            foreach (var formFile in files)
            {
                if (formFile.Length <= 0)
                {
                    continue;
                }

                var rootPath = _configuration["StoredFilesPath"];
                var filePath = Path.Combine(rootPath, Path.GetTempFileName());

                await using var stream = File.Create(filePath);
                await formFile.CopyToAsync(stream);

                paths.Add(filePath);
            }

            return paths;
        }
    }
}
