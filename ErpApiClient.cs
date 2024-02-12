using Microsoft.Extensions.Configuration;

public class ErpApiClient
{
    private readonly string? _baseUrl;

    public string? BaseUrl => _baseUrl;

    public ErpApiClient(IConfiguration configuration)
    {
        _baseUrl = configuration.GetValue<string>("ErpApiConfig:BaseUrl");
    }
}
