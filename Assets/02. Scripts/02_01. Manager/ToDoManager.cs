using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class ToDoManager : Singleton<ToDoManager>
    {
        [SerializeField] private Text taskCountText;

        public List_JSON currListObject { get; private set; }
        public Dictionary<int, List_JSON> ListDict { get; private set; }
        public SDictionary<int, Task_JSON> TaskDict { get; private set; }
        public readonly int MAX_ID_SIZE = 64;

        private void Awake()
        {
            ListDict = new Dictionary<int, List_JSON>();
        }

        public void OnClickCreateList()
        {
            ContentsManager.Instance.CreateList();
        }

        public void OnClickCreateTask()
        {
            ContentsManager.Instance.CreateTask();
        }

        public void SetCurrentListObject(List_JSON listObject)
        {
            currListObject = listObject;
        }

        public void SetCurrentTaskDictionay(SDictionary<int, Task_JSON> taskDict)
        {
            TaskDict = taskDict;
        }
    }
}
