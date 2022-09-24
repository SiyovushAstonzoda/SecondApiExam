namespace Domain.Dtos;

public class GetManagersDto
{
    public string? ManagerFullName { get; set; }
    public string? DepartmentName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public int ManagerId { get; set; }
    public int DepartmentId { get; set; }
}
