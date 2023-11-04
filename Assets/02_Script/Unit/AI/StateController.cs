using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController<T> : MonoBehaviour where T : Enum
{

    protected Dictionary<T, StateRoot<T>> controllState = new();
    protected T currentState = default;

    protected virtual void Start()
    {

        controllState[currentState].Enter();

    }

    protected virtual void Update()
    {

        controllState[currentState].Update();
        controllState[currentState].ChackTransition();

    }

    public void ChangeState(T key)
    {

        controllState[currentState].Exit();
        controllState[key].Enter();

        currentState = key;

    }
}
