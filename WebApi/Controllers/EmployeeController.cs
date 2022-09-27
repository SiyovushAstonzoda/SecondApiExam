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
public class EmployeeController : ControllerBase
{
    private IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetEmployees")]
  public async Task<Response<List<GetEmployeesDto>>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpGet("GetEmployeeById")]
   public async Task<Response<List<GetEmployeesDto>>> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }

    [HttpPost("AddEmployee")]
    public async Task<Response<Employee>> AddEmployee(Employee employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<Response<Employee>> UpdateEmployee(Employee employee)
    {
        return await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}
