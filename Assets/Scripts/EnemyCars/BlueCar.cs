using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCar : MonoBehaviour, ICar
{
    public void SpawnCar(Vector2 spawnPoint)
    {
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (transform.position.y > -12)
        {
            transform.position += new Vector3(0, -0.039f, 0);
        }
    }
}
