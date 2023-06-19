using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectBackgroundButton : MonoBehaviour, ISubject
{
    public GameObject MainListButton { get; private set; }
    public GameObject MainTaskButton { get; private set; }
    public List<IObserver> Observers { get; private set; }

    private void Awake()
    {
        Observers = new List<IObserver>();
    }

    public void NotifyObservers()
    {
        if (gameObject.tag == "Tag_List")
        {
            foreach (IObserver observer in Observers)
            {
                observer.UpdateData(MainListButton);
            }
        }
        else
        {
            foreach (IObserver observer in Observers)
            {
                observer.UpdateData(MainTaskButton);
            }
        }
    }
    public void ResisterObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void ReceiveObservers(GameObject selectedButton)
    {
        if (gameObject.tag == "Tag_List")
        {
            MainListButton = selectedButton;
            ContentsManager.Instance.ClearChildren();
            ToDoManager.Instance.SetCurrentListObject(MainListButton.GetComponentInChildren<ObserverBackgroundButton>().ListObject);
            ToDoManager.Instance.SetCurrentTaskDictionay(MainListButton.GetComponentInChildren<ObserverBackgroundButton>().ListObject.TaskDict);
            ContentsManager.Instance.ActivateTaskOfList();
        }
        else
        {
            MainTaskButton = selectedButton;
        }

        NotifyObservers();
    }
}
