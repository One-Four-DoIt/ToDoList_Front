using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class List_JSON
{
    public int ListID { get; private set; }
    public string ListName { get; private set; }
    public bool IsActive { get; set; }
    public bool IsCreate { get; set; }

    private Dictionary<int, Task_JSON> taskDict;

    public List_JSON(int id, string name) 
    {
        ListID = id;
        ListName = name;
        taskDict = new Dictionary<int, Task_JSON>();
    }

    public Dictionary<int, Task_JSON> GetTaskDict()
    {
        return taskDict;
    }
}
