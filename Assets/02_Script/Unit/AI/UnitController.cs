using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : StateController<UnitState>
{

    private void Awake()
    {

        controllState.Add(UnitState.Idle, new IdleState(transform, this));
        controllState.Add(UnitState.Skill, new SkillState(transform, this));
        controllState.Add(UnitState.Attack, new AttackState(transform, this));
        controllState.Add(UnitState.Move, new MoveState(transform, this));
        controllState.Add(UnitState.Die, new DieState(transform, this));

        currentState = UnitState.Idle; 

    }

}
