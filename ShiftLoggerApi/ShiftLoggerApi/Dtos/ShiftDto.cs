namespace ShiftLoggerApi.Dtos;

public record ShiftDto(int ShiftId, DateTime Date, DateTime ShiftStart, DateTime ShiftEnd, int EmployeeId)
{
    public TimeSpan ShiftDuration => ShiftEnd - ShiftStart;
}