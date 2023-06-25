namespace EnergyCompanyManager.Application;

public class Response<T>
{
    public Response(T data, bool success, string? errorMessage = null)
    {
        Data = data;
        Success = success;
        ErrorMessage = errorMessage;
    }

    public T Data { get; set; }

    public bool Success { get; set; }

    public string? ErrorMessage { get; set; }
}

public class Response
{
    public Response(bool success, string? errorMessage = null)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public bool Success { get; set; }

    public string? ErrorMessage { get; set; }
}