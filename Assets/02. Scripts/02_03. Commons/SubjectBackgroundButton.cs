using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectBackgroundButton : MonoBehaviour, ISubject
{
    private List<IObserver> observers;
    private GameObject mainListButton;
    private GameObject mainTaskButton;

    private void Awake()
    {
        observers = new List<IObserver>();
    }

    public void NotifyObservers()
    {
        if (gameObject.tag == "Tag_List")
        {
            foreach (IObserver observer in observers)
            {
                observer.UpdateData(mainListButton);
            }
        }
        else
        {
            foreach (IObserver observer in observers)
            {
                observer.UpdateData(mainTaskButton);
            }
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void ResisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void ReceiveObservers(GameObject selectedButton)
    {
        if (gameObject.tag == "Tag_List")
        {
            mainListButton = selectedButton;
        }
        else
        {
            mainTaskButton = selectedButton;
        }

        NotifyObservers();
    }
}
