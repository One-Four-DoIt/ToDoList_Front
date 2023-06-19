using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class Task_JSON : ScriptableObject
{
    [JsonProperty(PropertyName = "isChecked")]
    [field: SerializeField] public bool IsChecked { get; private set; }

    [JsonProperty(PropertyName = "taskID")]
    [field: SerializeField] public int TaskID { get; private set; }

    [JsonProperty(PropertyName = "taskName")]
    [field: SerializeField] public string TaskName { get; private set; }

    public Task_JSON(int taskID)
    {
        TaskID = taskID;
        TaskName = "";
    }
}
