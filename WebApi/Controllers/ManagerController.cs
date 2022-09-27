using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.DataContext;
using Infrastructure.Services;
using Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManagerController : ControllerBase
{
    private IManagerService _managerService;
    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet("GetManagers")]
  public async Task<Response<List<GetManagersDto>>> GetManagers()
    {
        return await _managerService.GetManagers();
    }

    [HttpPost("DepartmentManager")]
     public async Task<Response<DepartmentManager>> AddManagers(DepartmentManager manager)
    {
        return await _managerService.AddManagers(manager);
    }
}
