using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour,IResponsibility
{
    public FellowCar fellowCarPrefab;

    FellowCar fellowCar;

    public Button startButton;

    public InputButton leftInput;

    public InputButton rightInput;

    public IResponsibility NextIResponsibility { get; set; }

    private void Start()
    {
        SetNextResponsibility(FindObjectOfType<RoadController>());

        fellowCar = Instantiate(fellowCarPrefab);

        fellowCar.gameObject.SetActive(false);

        RaceFinish();

    }

    public void StartRace()
    {
        FindObjectOfType<GameFinishState>().OnStateExit(this);
        FindObjectOfType<GameStartState>().OnStateEnter(this);

    }

    public void RaceFinish()
    {
        FindObjectOfType<GameStartState>().OnStateExit(this);
        FindObjectOfType<GameFinishState>().OnStateEnter(this);
    }

    public void CarCrashed(IObservable fellowCar)
    {
        RaceFinish();
    }

    public void OnInputDown(InputType inputType)
    {
        fellowCar.PressedDown(inputType);
    }

    public void OnInputUp(InputType inputType)
    {
        fellowCar.PressedUp(inputType);
    }

    public void OpenCarInput()
    {
        leftInput.gameObject.SetActive(true);
        rightInput.gameObject.SetActive(true);

        leftInput.OnDown += OnInputDown;
        leftInput.OnUp += OnInputUp;

        rightInput.OnDown += OnInputDown;
        rightInput.OnUp += OnInputUp;
    }

    public void MakeReadyCar()
    {
        FindObjectOfType<CarSpawner>().SpawnFellowCar(fellowCar);
        fellowCar.gameObject.SetActive(true);
        fellowCar.Add(FindObjectOfType<CarCrashObserver>());
    }

    public void CloseCarInput()
    {
        leftInput.gameObject.SetActive(false);

        rightInput.gameObject.SetActive(false);

        leftInput.gameObject.SetActive(false);

        rightInput.gameObject.SetActive(false);
    }

    public void OpenButton()
    {
        startButton.gameObject.SetActive(true);
        startButton.onClick.AddListener(() => StartRace());
    }

    public void CloseButton()
    {
        startButton.gameObject.SetActive(false);
    }

    public void StartCarSpawn()
    {
        FindObjectOfType<CarSpawner>().startCarSpawn = true;
    }

    public void StartRoad()
    {

        FindObjectOfType<RoadController>().startedRoad = true;
    }

    public void SetNextResponsibility(IResponsibility nextResponse)
    {
        this.NextIResponsibility = nextResponse;
    }

    public void HandleResponse()
    {
        OpenButton();

        fellowCar.gameObject.SetActive(false);

        if (NextIResponsibility != null)
        {
            NextIResponsibility.HandleResponse();
        }      
    }
}
