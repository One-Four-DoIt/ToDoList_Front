using Newtonsoft.Json;
using System;

[Serializable]
public abstract class RP_Base
{
    [JsonProperty("code")]
    public int Code { get; private set; }
    [JsonProperty("message")]
    public string Messeage { get; private set; }
}
