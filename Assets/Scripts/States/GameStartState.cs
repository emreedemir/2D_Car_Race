using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartState : State
{
    public override void OnStateEnter(Game game)
    {
        game.OpenCarInput();
        game.MakeReadyCar();
        game.StartRoad();
        game.StartCarSpawn();
    }

    public override void OnStateExit(Game game)
    {
        game.CloseCarInput();
    }
}
