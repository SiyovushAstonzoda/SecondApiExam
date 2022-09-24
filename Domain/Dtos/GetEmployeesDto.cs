namespace Domain.Dtos;

public class GetEmployeesDto
{
    public string? FullName { get; set; }
    public string? DepartmentName { get; set; }

    public int Id { get; set; }
    public int DepartmentId  { get; set; }
}
