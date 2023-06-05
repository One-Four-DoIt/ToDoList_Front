using Newtonsoft.Json;

public class RQ_SignIn : RQ_Base
{
    [JsonProperty("email")]
    public string Email { get; private set; }
    [JsonProperty("password")]
    public string Password { get; private set; }

    public RQ_SignIn(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
