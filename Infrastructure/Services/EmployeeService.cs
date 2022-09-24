using Npgsql;
using Dapper;
using Domain.Wrapper;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.DataContext;
namespace Infrastructure.Services;

public class EmployeeService
{
    private DataContext.DataContext _context;
     public EmployeeService (DataContext.DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetEmployeesDto>>> GetEmployees()
    {
        await using var connection = _context.CreateConnection();
        var sql = "select e.Id, CONCAT(e.FirstName, ' ', e.LastName) as FullName, de.DepartmentId from Employee as e left join department_employee as de on de.employeeid = e.id;";
        var result = await connection.QueryAsync<GetEmployeesDto>(sql);
        return new Response<List<GetEmployeesDto>>(result.ToList());
    }

    public async Task<Response<List<GetEmployeesDto>>> GetEmployeeById(int id)
    {
        await using var connection = _context.CreateConnection();
        var sql = "select e.Id, CONCAT(e.FirstName, ' ', e.LastName) as FullName, de.DepartmentId from Employee as e left join department_employee as de on de.employeeid = e.id where Id = {id};";
        var result = await connection.QueryAsync<GetEmployeesDto>(sql);
        return new Response<List<GetEmployeesDto>>(result.ToList());
    }

    public async Task<Response<Employee>> AddEmployee(Employee employee)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = "insert into Employee (BirthDate, FirstName, LastName, HireDate, Gender) values (@BirthDate, @FirstName, @LastName, @HireDate, @Gender) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql, new {employee.BirthDate, employee.FirstName, employee.LastName, employee.HireDate, employee.Gender});
            employee.Id = result;
            return new Response<Employee>(employee);
        }
        catch (Exception ex)
        {
            return new Response<Employee>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

     public async Task<Response<Employee>> UpdateEmployee(Employee employee)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"update Employee set BirthDate = @BirthDate, FirstName = @FirstName, LastName = @LastName, HireDate = @HireDate, Gender = @Gender  where Id = @Id returning Id";
            var response  = await connection.ExecuteScalarAsync<int>(sql, new{employee.BirthDate, employee.FirstName, employee.LastName, employee.HireDate, employee.Gender, employee.Id});
            employee.Id = response;
            return new Response<Employee>(employee);
        }
        }
         catch (Exception e)
        {     
           return new Response<Employee>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }  
       
    }

     public async Task<Response<string>> DeleteEmployee(int id)
    {
        try
        {
             using var connection = _context.CreateConnection();
        {
            string sql = $"delete from Employee where Id = {id}";
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
