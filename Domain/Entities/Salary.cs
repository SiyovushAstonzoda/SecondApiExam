namespace Domain.Entities;

public class Salary
{
    public int Amount { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public int Id { get; set; }
    public int EmployeeId { get; set; }
}
