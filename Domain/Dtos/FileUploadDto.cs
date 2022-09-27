using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;

public class FileUploadDto
{
    public IFormFile File { get; set; }
}
