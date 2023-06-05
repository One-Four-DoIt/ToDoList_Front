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
    private Toggle toggle;
    private bool isSelected = false;
    #endregion

    private void Awake()
    {
        Button[] children = GetComponentsInChildren<Button>(true);
        edit = children[children.Length-2].gameObject;
        delete = children[children.Length-1].gameObject;
        toggle = GetComponentInChildren<Toggle>();
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
