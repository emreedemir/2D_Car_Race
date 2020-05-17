using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : Singleton<CarFactory>,IResponsibility
{
    public RedCar redCar;

    public BlueCar blueCar;

    public GreenCar greenCar;

    public IResponsibility NextIResponsibility { get ; set ; }

    public ICar GetCar(CarType carType)
    {
        if (carType == CarType.RedCar)
        {
            return redCar;
        }
        else if (carType == CarType.BlueCar)
        {
            return blueCar;
        }
        else
        {
            return greenCar;
        }
    }

    private void Start()
    {

        SetNextResponsibility(FindObjectOfType<CarSpawner>());

        redCar = Instantiate(redCar);
        redCar.gameObject.SetActive(false);

        blueCar = Instantiate(blueCar);
        blueCar.gameObject.SetActive(false);

        greenCar = Instantiate(greenCar);
        greenCar.gameObject.SetActive(false);
    }

    private void CloseAll()
    {
        redCar.gameObject.SetActive(false);
        blueCar.gameObject.SetActive(false);
        greenCar.gameObject.SetActive(false);
    }

    public void SetNextResponsibility(IResponsibility nextResponse)
    {
        NextIResponsibility = nextResponse;
    }

    public void HandleResponse()
    {     
       CloseAll();
       NextIResponsibility.HandleResponse();
    }
}

