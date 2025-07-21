namespace ShiftLoggerUi.Dtos;

public record ShiftDto(DateTime ShiftDate, TimeSpan ShiftStart, TimeSpan ShiftEnd, int EmployeeId, int ShiftId = 0)
{
    public TimeSpan ShiftDuration => ShiftEnd - ShiftStart;
}