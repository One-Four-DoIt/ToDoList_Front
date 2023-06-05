using Newtonsoft.Json;

public class RP_CheckEmailDuplicated : RP_Base
{
    [JsonProperty("data")]
    public bool Data { get; private set; }
}
