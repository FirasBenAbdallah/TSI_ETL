using Microsoft.Extensions.Configuration;

public class ErpApiClient
{
    private readonly string? _dbConnection;
    private readonly string? _baseUrl;
    private readonly string? _loginUrl;

    public string? DbConnection => _dbConnection;
    public string? BaseUrl => _baseUrl;
    public string? LoginUrl => _loginUrl;

    public ErpApiClient(IConfiguration configuration)
    {
        _dbConnection = configuration.GetValue<string>("ErpApiConfig:DbConnection");
        _baseUrl = configuration.GetValue<string>("ErpApiConfig:BaseUrl");
        _loginUrl = _baseUrl + configuration.GetValue<string>("ErpApiConfig:Login");
    }
}
