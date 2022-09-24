using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.DataContext;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("GetDepartments")]
  public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        return await _departmentService.GetDepartments();
    }

    [HttpGet("GetDepartmentById")]
   public async Task<Response<List<GetDepartmentsDto>>> GetDepartmentById(int id)
    {
        return await _departmentService.GetDepartmentById(id);
    }

    [HttpPost("AddDepartment")]
   public async Task<Response<Department>> AddDepartment(Department department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<Response<Department>> UpdateDepartment(Department department)
    {
        return await _departmentService.UpdateDepartment(department);
    }

    [HttpDelete("DeleteDepartment")]
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        return await _departmentService.DeleteDepartment(id);
    }
}
