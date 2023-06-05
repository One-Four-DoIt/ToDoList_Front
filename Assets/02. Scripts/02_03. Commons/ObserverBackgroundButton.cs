using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;


public class ObserverBackgroundButton : MonoBehaviour, IObserver
{
    [SerializeField]
    private SubjectBackgroundButton provider;
    private GameObject edit;
    private GameObject delete;

    #region Tag_Task Variables
    private Toggle taskToggle;
    private bool isSelected = false;
    #endregion

    private void Awake()
    {
        Button[] children = GetComponentsInChildren<Button>(true);
        edit = children[children.Length-2].gameObject;
        delete = children[children.Length-1].gameObject;

        if (gameObject.tag == "Tag_Task")
        {
            taskToggle = gameObject.GetComponentInChildren<Toggle>();
        }
    }

    private void Start()
    {
        provider.ResisterObserver(this);
    }

    // Test Function
    //public void OnClickSendListButtonID()
    //{
    //    ToDoManager.Instance.ListActivateTasks();
    //}



    #region Code Used To Observer Pattern
    public void OnClickActivate()
    {
        if (isSelected == true && gameObject.tag == "Tag_Task")
        {
            if (taskToggle.isOn == true)
            {
                taskToggle.isOn = false;
            }
            else
            {
                taskToggle.isOn = true;
            }
        }
        else
        {
            isSelected = true;
        }

        edit.SetActive(true);
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
