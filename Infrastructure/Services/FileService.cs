using Domain.Wrapper;
using Domain.Dtos;
using Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<Response<string>> UploadFile(FileUploadDto upload)
    {
        try
        {
            if(upload.File != null)
            {
                var roothpath = _environment.WebRootPath;
                var path = Path.Combine(roothpath, "images", upload.File.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await upload.File.CopyToAsync(stream);
                }
                return new Response<string>(System.Net.HttpStatusCode.OK, "File Uploaded");
            }
            else
            {
                return new Response<string>(System.Net.HttpStatusCode.BadRequest, "File is null");
            }     
        }
        catch (Exception e)
        {    
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }  
}
