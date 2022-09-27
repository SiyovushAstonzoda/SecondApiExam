namespace Infrastructure.ServiceInterfaces;
using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;

public interface IManagerService
{
    Task<Response<List<GetManagersDto>>> GetManagers();
    Task<Response<DepartmentManager>> AddManagers(DepartmentManager manager); 
}
