using Domain.Wrapper;
using Domain.Dtos;
namespace Infrastructure.ServiceInterfaces;

public interface IFileService
{
    Task<Response<string>> UploadFile(FileUploadDto upload);
}
