using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateRoot<T> where T : System.Enum
{

    public StateRoot(Transform transform, StateController<T> stateController)
    {

        this.transform = transform;
        this.stateController = stateController;

    }

    protected Dictionary<T, HashSet<TransitionRoot>> transitions = new();
    protected Transform transform;
    protected StateController<T> stateController;

    public abstract void Update();

    public virtual void Enter() { }
    public virtual void Exit() { }

    public void ChackTransition()
    {

        foreach(var item in transitions)
        {

            bool change = true;

            foreach(var trans in item.Value)
            {

                if (!trans.ChackTransition())
                {

                    change = false;
                    break;

                }

            }

            if (change)
            {

                stateController.ChangeState(item.Key);

            }

        }

    }

}

public abstract class TransitionRoot
{

    public abstract bool ChackTransition();

}