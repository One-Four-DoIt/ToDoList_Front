using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISubject
{
    //옵저버 등록
    void ResisterObserver(IObserver observer);
    //옵저버 제거
    void RemoveObserver(IObserver observer);
    //옵저버들에게 내용 전달
    void NotifyObservers();

    void ReceiveObservers(GameObject mainGameObject);

}
