using Npgsql;
using Dapper;
using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.DataContext;
using Infrastructure.ServiceInterfaces;

namespace Infrastructure.Services;

public class ManagerService : IManagerService
{
    private DataContext.DataContext _context;
     public ManagerService (DataContext.DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetManagersDto>>> GetManagers()
    {
        await using var connection = _context.CreateConnection();
        var sql = "select dm.employeeid as ManagerId ,concat(e.firstname , ' ' , e.lastname) as ManagerFullName ,dm.departmentid , d.name as DepartmentName ,  dm.fromdate , dm.todate FROM department_manager dm JOIN employee e ON e.id = dm.employeeid join department d ON dm.departmentid = d.id ;";
        var result = await connection.QueryAsync<GetManagersDto>(sql);
        return new Response<List<GetManagersDto>>(result.ToList());
    }

   public async Task<Response<DepartmentManager>> AddManagers(DepartmentManager manager)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = "insert into department_manager (EmployeeId, DepartmentId, FromDate,) values (@EmployeeId, @DepartmentId, @FromDate) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql, new {manager.EmployeeId, manager.DepartmentId, manager.FromDate});
            manager.EmployeeId = result;
            return new Response<DepartmentManager>(manager);
        }
        catch (Exception ex)
        {
            return new Response<DepartmentManager>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
