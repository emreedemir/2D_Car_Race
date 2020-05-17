using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State :MonoBehaviour
{
    public abstract void OnStateEnter(Game game);

    public abstract void OnStateExit(Game game);
}
