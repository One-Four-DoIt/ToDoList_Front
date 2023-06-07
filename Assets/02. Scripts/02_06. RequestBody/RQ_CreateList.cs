using Newtonsoft;
using Newtonsoft.Json;

public class RQ_CreateList : RQ_Base
{
    [JsonProperty("endDate")]
    public string Deadline { get; private set; }
    
    [JsonProperty("title")]
    public string ListName { get; private set; }

    public RQ_CreateList(string listName, string deadline)
    {
        ListName = listName;
        Deadline = deadline;
    }
}
