using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISubject
{
    //������ ���
    void ResisterObserver(IObserver observer);
    //������ ����
    void RemoveObserver(IObserver observer);
    //�������鿡�� ���� ����
    void NotifyObservers();

    void ReceiveObservers(GameObject mainGameObject);

}
