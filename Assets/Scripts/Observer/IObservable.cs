using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable 
{
    void Add(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
