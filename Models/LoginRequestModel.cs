namespace TSI_ERP_ETL.Models
{
    public class LoginRequestModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

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
