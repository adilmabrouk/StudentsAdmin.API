using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StudentsAdmin.API.Repository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}
