namespace ShiftLoggerUi.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly HttpClient _httpClient;
    
    public ShiftRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7145/");
    }
}