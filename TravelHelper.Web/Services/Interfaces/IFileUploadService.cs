using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TravelHelper.Web.Services.Interfaces
{
    public interface IFileUploadService
    {
        Task<IEnumerable<string>> UploadAsync(params IFormFile[] files);
    }
}
