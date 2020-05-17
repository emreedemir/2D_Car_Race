using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashObserver : MonoBehaviour, IObserver
{
    public void UpdateObserver(IObservable observable)
    {
        FindObjectOfType<Game>().CarCrashed(observable);
    }
}
