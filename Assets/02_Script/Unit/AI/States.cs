using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{

    Idle,
    Attack,
    Die

}

public abstract class UnitStateRoot : StateRoot<UnitState>
{
    protected UnitStateRoot(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {
    }

    public abstract override void Update()


}

public class Attakc