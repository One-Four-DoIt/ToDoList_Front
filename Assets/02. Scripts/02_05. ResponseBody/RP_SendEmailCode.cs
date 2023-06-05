using Newtonsoft.Json;

public class RP_SendEmailCode : RP_Base
{
    [JsonProperty("data")]
    public string Data { get; private set; }
}
