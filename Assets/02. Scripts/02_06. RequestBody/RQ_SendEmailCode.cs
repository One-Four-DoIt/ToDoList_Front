using Newtonsoft.Json;

public class RQ_SendEmailCode : RQ_Base
{
    [JsonProperty("email")]
    public string Email { get; private set; }

    public RQ_SendEmailCode(string email)
    {
        Email = email;
    }
}
