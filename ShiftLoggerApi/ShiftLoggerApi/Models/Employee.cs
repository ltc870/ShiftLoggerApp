using System.ComponentModel.DataAnnotations;

namespace ShiftLoggerApi.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    public List<Shift>? Shifts { get; set; }
}