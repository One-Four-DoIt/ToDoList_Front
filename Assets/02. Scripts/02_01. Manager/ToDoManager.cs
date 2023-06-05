using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.EventSystems;

namespace Manager
{
    public class ToDoManager : Singleton<ToDoManager>
    {
        private Dictionary<int, List_JSON> listDict;
        private int curListID = 0;

        private void Awake()
        {
            listDict = new Dictionary<int, List_JSON>();
        }

        public void ListActivateTasks(int newListID)
        {
            // 클릭한 list가 현재 list인지 확인
            if (curListID == newListID)
            {
                return;
            }

            // 현재 활성화된 task들을 비활성화
            Dictionary<int, Task_JSON> taskDict = listDict[curListID].GetTaskDict();
            for (int index = 0; index < taskDict.Count; index++)
            {
                ContentsManager.Instance.TaskContent.GetChild(index).gameObject.SetActive(false);
            }
            listDict[curListID].IsActive = false;
            
            // 클릭한 list의 task들을 활성화 또는 생성
            taskDict = listDict[newListID].GetTaskDict();
            if (listDict[newListID].IsCreate == false)
            {
                for (int i = 0; i < taskDict.Count; i++)
                {
                    RectTransform taskInstance = Instantiate(ContentsManager.Instance.taskPrefab);
                    // listDict[newListID].GetTaskDict().Add(taskInstance.gameObject.GetInstanceID(), new TD_Task(/*id, name*/));
                    taskInstance.SetParent(ContentsManager.Instance.TaskContent.transform);
                }
                listDict[newListID].IsActive = true;
            }
            else
            {
                
            }

            curListID = newListID;
        }
    }
}
