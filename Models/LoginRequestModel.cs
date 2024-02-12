namespace TSI_ERP_ETL.Models
{
    public class LoginRequestModel
    {
        public required string UserName { get; set; }
        public string Password { get; set; } = string.Empty;

        public LoginRequestModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    public class LoginResponse
    {
        public string? Token { get; set; }
    }

}
