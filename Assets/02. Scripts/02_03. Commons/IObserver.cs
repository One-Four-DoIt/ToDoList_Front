using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IObserver
{
    public void UpdateData(GameObject mainGameObject);

    public void SetMainButtonData(GameObject mainGameObject);
}
