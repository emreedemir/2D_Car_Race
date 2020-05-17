using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowCar : MonoBehaviour, ICar,IObservable
{
    public List<IObserver> observers = new List<IObserver>();


    public float currentSpeed { get; set; }

    public bool left;

    public bool right;

    float maxClamp;

    float minClamp;

    public bool stopFellow { set; get; }

    private void OnEnable()
    {
        left = false;
        right = false;
    }
    void Start()
    {
        
        maxClamp = (2 * FindObjectOfType<Camera>().orthographicSize +FindObjectOfType<Camera>().aspect)/5;

        minClamp = -(2 * FindObjectOfType<Camera>().orthographicSize + FindObjectOfType<Camera>().aspect) / 5;
    }

    public void SpawnCar(Vector2 spawnPoint)
    {
        transform.position = spawnPoint;
    }

    void Update()
    {
        if (stopFellow == false)
        {
            if (right == true)
            {
                if (transform.position.x < maxClamp)
                {
                    this.transform.position += new Vector3(0.1f, 0, 0);
                }
            }
            if (left == true)
            {
                if (transform.position.x > minClamp)
                {
                    this.transform.position += new Vector3(-0.1f, 0, 0);
                }
            }
        }
    }

    public void PressedDown(InputType inputType)
    {
        if (inputType == InputType.left)
        {
            left = true;
        }
        else
        {
            right = true;
        }
    }

    public void PressedUp(InputType inputType)
    {
        if (inputType == InputType.left)
        {
            left = false;
        }
        else
        {
            right = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Car crasehed");
        NotifyObservers();
    }
    public void Add(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        observers.ForEach(observer => observer.UpdateObserver(this));
    }
}
