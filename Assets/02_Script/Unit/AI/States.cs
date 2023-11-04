using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{

    Idle,
    Attack,
    Skill,
    Die

}

public abstract class UnitStateRoot : StateRoot<UnitState>
{

    protected UnitDataController dataController;

    protected UnitStateRoot(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {

        dataController = transform.GetComponent<UnitDataController>();

    }

    public abstract override void Update();

}

public class IdleState : UnitStateRoot
{
    public IdleState(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {

        var attackRangeTrans = new AttackTransition(dataController.attackRange, transform);
        var skillRangeTrans = new RangeTransition(dataController.skillRange, transform);

        transitions.Add(UnitState.Attack, new HashSet<TransitionRoot> { attackRangeTrans });
        transitions.Add(UnitState.Skill, new HashSet<TransitionRoot> { skillRangeTrans });

    }

    public override void Update()
    {

        

    }

}

public class AttackState : UnitStateRoot
{
    public override void Update()
    {



    }

}
