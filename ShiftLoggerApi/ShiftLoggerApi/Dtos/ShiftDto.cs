namespace ShiftLoggerApi.Dtos;

public record ShiftDto(int ShiftId, DateTime ShiftDate, TimeSpan ShiftStart, TimeSpan ShiftEnd, int EmployeeId)
{
    public TimeSpan ShiftDuration => ShiftEnd - ShiftStart;
}