using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTransition : TransitionRoot
{

    public RangeTransition(float range, Transform transform)
    {

        this.transfrom = transform;
        this.range = range;

    }

    private Transform transfrom;

    public float range;
    public Transform target;

    public override bool ChackTransition()
    {

        return Vector3.Distance(transfrom.position, target.position) < range;

    }

    public void SetTarget(Transform target)
    {

        this.target = target;

    }

}

public class ReverseRangeTransition : RangeTransition
{
    public ReverseRangeTransition(float range, Transform transform) : base(range, transform)
    {
    }

    public override bool ChackTransition()
    {

        return !base.ChackTransition();

    }

}

public class AttackTransition : RangeTransition
{

    private UnitDataController dataController;

    public AttackTransition(float range, Transform transform) : base(range, transform)
    {

        dataController = transform.GetComponent<UnitDataController>();

    }

    public override bool ChackTransition()
    {

        return base.ChackTransition() && dataController.attackAble;

    }

}

public class SkillTransition : RangeTransition
{

    private UnitDataController dataController;

    public SkillTransition(float range, Transform transform) : base(range, transform)
    {

        dataController = transform.GetComponent<UnitDataController>();

    }

    public override bool ChackTransition()
    {

        return base.ChackTransition() && dataController.skillAble;

    }

}