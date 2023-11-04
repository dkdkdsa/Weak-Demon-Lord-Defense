using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum UnitState
{

    Idle,
    Move,
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

        var attackRangeTrans = new AttackTransition(dataController.attackAbleRange, transform);
        var skillRangeTrans = new SkillTransition(dataController.attackAbleRange, transform);
        var moveTrans = new RangeTransition(dataController.range, transform);
        moveTrans.SetLayer(dataController.targetLayer);

        transitions.Add(UnitState.Attack, new HashSet<TransitionRoot> { attackRangeTrans });
        transitions.Add(UnitState.Skill, new HashSet<TransitionRoot> { skillRangeTrans });

    }

    public override void Update()
    {

        

    }

}

public class AttackState : UnitStateRoot
{
    public AttackState(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {
    }

    public override void Exit()
    {

        //Doattack

        dataController.attackAble = false;

        FAED.InvokeDelay(() => dataController.attackAble = true, dataController.attackTime);

    }

    public override void Update()
    {



    }

}

public class SkillState : UnitStateRoot
{


    public SkillState(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {
    }

    public override void Exit()
    {

        //DoSkill

        dataController.skillAble = false;

        FAED.InvokeDelay(() => dataController.skillAble = true, dataController.skillCoolDown);

    }

    public override void Update()
    {



    }

}

public class MoveState : UnitStateRoot
{


    public MoveState(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {

        var attackRangeTrans = new AttackTransition(dataController.attackAbleRange, transform);
        var skillRangeTrans = new SkillTransition(dataController.attackAbleRange, transform);
        var idleTrans = new ReverseRangeTransition(dataController.range, transform);
        idleTrans.SetLayer(dataController.targetLayer);

        transitions.Add(UnitState.Attack, new HashSet<TransitionRoot> { attackRangeTrans });
        transitions.Add(UnitState.Skill, new HashSet<TransitionRoot> { skillRangeTrans });

        agent = transform.GetComponent<NavMeshAgent>();
        agent.speed = dataController.moveSpeed;
        agent.angularSpeed = 0;

    }

    private NavMeshAgent agent;
    private Transform target;

    private void SetTarget()
    {

        var hits = Physics.OverlapSphere(transform.position, dataController.range, dataController.targetLayer);
        if (hits.Length <= 0) return;

        target = hits[ChackMin(hits)].transform;
        
    }

    private int ChackMin(Collider[] arr)
    {

        int min = 0;
        float minDist = float.MaxValue;

        if(arr.Length == 1)
        {

            return 0;

        }

        for(int i = 0; i < arr.Length; i++)
        {

            var dist = Vector3.Distance(transform.position, arr[i].transform.position);

            if (dist < minDist)
            {

                minDist = dist; 
                min = i;

            }

        }

        return min;

    }

    public override void Enter()
    {

        agent.isStopped = false;

    }

    public override void Exit()
    {

        agent.Move(transform.position);
        agent.isStopped = true;

    }

    public override void Update()
    {

        if(target == null)
        {

            SetTarget();

        }

        if (target == null) return;

        agent.Move(target.position);

    }

}

public class DieState : UnitStateRoot
{
    public DieState(Transform transform, StateController<UnitState> stateController) : base(transform, stateController)
    {
    }

    public override void Update()
    {
    }
}
