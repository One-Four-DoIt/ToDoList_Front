using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]

public class Task_JSON
{
    [JsonProperty(PropertyName = "isChecked")]
    public bool IsChecked {  get; private set; }
    [JsonProperty(PropertyName = "taskID")]
    public int TaskID { get; private set; }
    [JsonProperty(PropertyName = "taskName")]
    public string TaskName { get; private set; }

    public Task_JSON(int taskID, string taskName)
    {
        TaskID = taskID;
        TaskName = taskName;
    }
}
