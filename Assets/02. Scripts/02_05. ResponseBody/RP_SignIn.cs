using Newtonsoft.Json;

public class RP_SignIn : RP_Base
{
    public class Token
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; private set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; private set; }
    }

    public Token Data;
}