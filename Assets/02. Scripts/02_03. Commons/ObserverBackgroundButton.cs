using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using System;

public class ObserverBackgroundButton : MonoBehaviour, IObserver
{
    public List_JSON ListObject { get; private set; }
    public Task_JSON TaskObject { get; private set; }

    private SubjectBackgroundButton provider;
    private GameObject edit;
    private GameObject calendar;
    private GameObject delete;

    private Toggle toggle;
    private bool isSelected = false;

    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();

        Button[] children = GetComponentsInChildren<Button>(true);
        if (tag == "Tag_List")
        {
            edit = children[children.Length - 3].gameObject;
            calendar = children[children.Length - 2].gameObject;
            delete = children[children.Length-1].gameObject;
        }
        else
        {
            edit = children[children.Length - 2].gameObject;
            delete = children[children.Length - 1].gameObject;
        }
    }

    private void Start()
    {
        if (tag == "Tag_List")
        {
            provider = ContentsManager.Instance.ListContent.GetComponent<SubjectBackgroundButton>();

            // 저장된 데이터가 있다면
            List_JSON listData = GetComponent<ListDataContainer>().listData;
            if (listData != null)
            {
                ListObject = new List_JSON(
                    listData.ListObjectID,
                    listData.ListObjectName,
                    listData.IsActive,
                    listData.TaskDict);

                if (ListObject.IsActive)
                {
                    toggle.isOn = ListObject.IsActive;
                }
            }
            else
            {
                int hashCode;
                do
                {
                    hashCode = GetHashCode();
                } while (ToDoManager.Instance.ListDict.ContainsKey(hashCode) == true);
                ListObject = new List_JSON(hashCode);
            }
        }
        else
        {
            provider = ContentsManager.Instance.TaskContent.GetComponent<SubjectBackgroundButton>();

            TaskObject = new Task_JSON(ToDoManager.Instance.TaskDict.Count);
            ListObject = ToDoManager.Instance.currListObject;
            //ListObject.TaskDict.Add(new SDictionary<int, taskob>)
        }

        provider.ResisterObserver(this);
    }

    private void OnDisable()
    {
        provider.RemoveObserver(this);
    }

    private void OnDestroy()
    {
        //ListObject.TaskDict.Remove(taskObject.TaskID);
        provider.RemoveObserver(this);
    }

    public void OnClickDestroy()
    {
        if (tag == "Tag_List")
        {
            ToDoManager.Instance.ListDict.Remove(ListObject.ListObjectID);
        }
        else
        {
            ToDoManager.Instance.TaskDict.Remove(TaskObject.TaskID);
        }

        Destroy(gameObject);
    }

    public void ApplyListData()
    {

    }

    #region Code Used To Observer Pattern
    public void OnClickActivate()
    {
        if (isSelected == true)
        {
            if (toggle.isOn == true)
            {
                toggle.isOn = false;
            }
            else
            {
                toggle.isOn = true;
            }
        }
        else
        {
            isSelected = true;
        }

        edit.SetActive(true);
        if (tag == "Tag_List")
        {
            calendar.SetActive(true);
        }
        delete.SetActive(true);
        SetMainButtonData(gameObject);
    }

    public void UpdateData(GameObject mainGameObject)
    {
        if (mainGameObject == null)
        {
            Debug.LogError("NULL");
            return;
        }    

        if (gameObject.GetInstanceID() != mainGameObject.GetInstanceID())
        {
            edit.gameObject.SetActive(false);
            if (tag == "Tag_List")
            {
                calendar.gameObject.SetActive(false);
            }
            delete.gameObject.SetActive(false);
            isSelected = false;
        }
    }

    public void SetMainButtonData(GameObject selectedButton)
    {
        provider.ReceiveObservers(selectedButton);
    }
    #endregion
}
