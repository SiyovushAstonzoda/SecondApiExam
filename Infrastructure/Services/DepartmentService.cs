using Npgsql;
using Dapper;
using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.DataContext;
namespace Infrastructure.Services;

public class DepartmentService
{
    private DataContext.DataContext _context;
     public DepartmentService (DataContext.DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        await using var connection = _context.CreateConnection();
        var sql = "select d.Id, d.Name, concat (em.FirstName, ' ',em.lastname) as fullname, em.Id FROM department as d Left JOIN department_manager  as dm ON dm.DepartmentId=d.ID Left JOIN employee as em ON em.Id=dm.EmployeeId;";
        var result = await connection.QueryAsync<GetDepartmentsDto>(sql);
        return new Response<List<GetDepartmentsDto>>(result.ToList());
    }

    public async Task<Response<List<GetDepartmentsDto>>> GetDepartmentById(int id)
    {
        await using var connection = _context.CreateConnection();
        var sql = $"select d.Id, d.Name, concat (em.FirstName, ' ',em.lastname) as fullname, em.Id FROM department as d Left JOIN department_manager  as dm ON dm.DepartmentId=d.ID Left JOIN employee as em ON em.Id=dm.EmployeeId where d.Id = {id};";
        var result = await connection.QueryAsync<GetDepartmentsDto>(sql);
        return new Response<List<GetDepartmentsDto>>(result.ToList());
    }

    public async Task<Response<Department>> AddDepartment(Department department)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = "insert into Department (Name) values (@Name) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql, new {department.Name});
            department.Id = result;
            return new Response<Department>(department);
        }
        catch (Exception ex)
        {
            return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

     public async Task<Response<Department>> UpdateDepartment(Department department)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"update Department set Name = @Name where Id = @Id returning Id";
            var response  = await connection.ExecuteScalarAsync<int>(sql, new{department.Name});
            department.Id = response;
            return new Response<Department>(department);
        }
        }
         catch (Exception e)
        {     
           return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }  
       
    }

    public async Task<Response<string>> DeleteDepartment(int id)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"delete from Department where Id = {id}";
            var response  = await connection.ExecuteScalarAsync<int>(sql);
            id = response;
            return new Response<string>("Success");
        }
        }
         catch (Exception e)
        {
           return new Response<string>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }
}
