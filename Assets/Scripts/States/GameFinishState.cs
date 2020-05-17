using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishState : State
{
    public override void OnStateEnter(Game game)
    {
        game.HandleResponse();
    }

    public override void OnStateExit(Game game)
    {
        game.CloseButton();
    }
}
