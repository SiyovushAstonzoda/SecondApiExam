namespace Domain.Entities;

public class Employee
{
    public DateTime BirthDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Gender { get; set; }
    public DateTime HireDate { get; set; }
    
    public int Id { get; set; }
}
