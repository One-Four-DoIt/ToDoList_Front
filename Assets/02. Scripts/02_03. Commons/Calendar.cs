using System.Collections;
using System.Collections.Generic;
using UI.Dates;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    [SerializeField] private GameObject datePicker;

    public void OnClickCalendar()
    {
        if (datePicker.activeSelf)
        {
            datePicker.SetActive(false);
        }
        else
        {
            datePicker.SetActive(true);
        }
    }
}
