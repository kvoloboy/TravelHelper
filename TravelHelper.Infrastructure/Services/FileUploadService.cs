using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TravelHelper.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;

        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task UploadAsync(params IFormFile[] files)
        {
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
            }
        }
    }
}
