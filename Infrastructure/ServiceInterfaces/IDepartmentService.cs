namespace Infrastructure.ServiceInterfaces;
using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;

public interface IDepartmentService
{
    Task<Response<List<GetDepartmentsDto>>> GetDepartments();
    Task<Response<List<GetDepartmentsDto>>> GetDepartmentById(int id);
    Task<Response<Department>> AddDepartment(Department department);
    Task<Response<Department>> UpdateDepartment(Department department);
    Task<Response<string>> DeleteDepartment(int id);
}
