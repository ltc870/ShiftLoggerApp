using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShiftLoggerApi.Models;

public class Shift
{
    [Key]
    public int ShiftId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime ShiftDate { get; set; }
    [Required]
    [DataType(DataType.Time)]
    public TimeSpan ShiftStart { get; set; }
    [Required]
    [DataType(DataType.Time)]
    public TimeSpan ShiftEnd { get; set; }
    [Required]
    public TimeSpan ShiftDuration { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}