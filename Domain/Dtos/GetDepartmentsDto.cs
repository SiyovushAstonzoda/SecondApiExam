namespace Domain.Dtos;

public class GetDepartmentsDto
{
    public string? Name { get; set; }
    public string? ManagerFullName { get; set; }

    public int Id { get; set; }
    public int ManagerId { get; set; }
}
