using System;
using Manager;
using UnityEngine;

[CreateAssetMenu]
[Serializable]
public class List_JSON : ScriptableObject
{
    [field: SerializeField] public int ListObjectID { get; private set; }
    [field: SerializeField] public string ListObjectName { get; private set; }
    [field: SerializeField] public bool IsActive { get; set; }
    [field: SerializeField] public SDictionary<int, Task_JSON> TaskDict { get; private set; }

    public List_JSON(int hashCode)
    {
        ListObjectID = hashCode;
        ListObjectName = "";
        IsActive = false;
        TaskDict = new SDictionary<int, Task_JSON>();
    }

    public List_JSON(int id, string name, bool isActive, SDictionary<int, Task_JSON> taskDict)
    {
        ListObjectID = id;
        ListObjectName = name;
        IsActive = isActive;
        TaskDict = taskDict;
    }

    public void SetListObjectID(int id)
        => ListObjectID = id;

    public void SetListObjectName(string name)
        => ListObjectName = name;

    public void SetTaskDict(SDictionary<int, Task_JSON> taskDict)
        => TaskDict = taskDict;
}