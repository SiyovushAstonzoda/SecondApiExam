using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.DataContext;
using Infrastructure.ServiceInterfaces;
using Infrastructure.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileservice;

    public FileController(IFileService fileService)
    {
        _fileservice = fileService;
    }

    [HttpPost ("UploadFile")]
    public Task<Response<string>> UploadFile([FromForm] FileUploadDto fileUploadDto)
    {
        return _fileservice.UploadFile(fileUploadDto);
    }
}
