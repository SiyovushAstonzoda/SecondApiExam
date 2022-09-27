namespace Infrastructure.ServiceInterfaces;
using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;


public interface IEmployeeService
{
     Task<Response<List<GetEmployeesDto>>> GetEmployees();
     Task<Response<List<GetEmployeesDto>>> GetEmployeeById(int id);
     Task<Response<Employee>> AddEmployee(Employee employee);
     Task<Response<Employee>> UpdateEmployee(Employee employee);
     Task<Response<string>> DeleteEmployee(int id);
}
