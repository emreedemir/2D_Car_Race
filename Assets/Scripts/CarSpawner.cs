using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CarSpawner : MonoBehaviour,IResponsibility
{
    public List<Transform> enemyCarSpawnPoints;

    public Transform fellowCarSpawnPoint;

    public bool startCarSpawn { get; set; }

    public IResponsibility NextIResponsibility { get ; set; }

    public ICar GetCar()
    {
        int randValue = UnityEngine.Random.Range(0, 2);

        CarType carType = (CarType)randValue;

        return CarFactory.Instance.GetCar(carType);
    }

    public void SpawnEnemyCar()
    {
        ICar enemyCar = GetCar();

        
        Transform randomPosition = enemyCarSpawnPoints[UnityEngine.Random.Range(0, 2)];

        enemyCar.SpawnCar(new Vector2(randomPosition.position.x, randomPosition.position.y));
    }

    public void SpawnFellowCar(ICar car)
    {
        car.SpawnCar(new Vector2(fellowCarSpawnPoint.transform.position.x, fellowCarSpawnPoint.transform.position.y));
    }

    float deltaTime = 0;

    private void Update()
    {
        deltaTime += Time.deltaTime;

        if (startCarSpawn == true)
        {
            if (deltaTime > 6)
            {
                SpawnEnemyCar();
                deltaTime = 0;
            }
        }
    }

    public void SetNextResponsibility(IResponsibility nextResponse)
    {
        NextIResponsibility = nextResponse;
    }

    public void HandleResponse()
    {
        startCarSpawn = false;

        if (NextIResponsibility != null)
        {
            NextIResponsibility.HandleResponse();
        }
    }
}
