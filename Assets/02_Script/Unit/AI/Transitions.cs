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

    protected Transform transfrom;
    protected LayerMask targetLayer;

    public float range;

    public void SetLayer(LayerMask layer)
    {

        targetLayer = layer;

    }
    public override bool ChackTransition()
    {

        var hits = Physics.OverlapSphere(transfrom.position, range, targetLayer);

        return hits.Length > 0;

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
        targetLayer = dataController.targetLayer;

    }

    public override bool ChackTransition()
    {

        return base.ChackTransition() && dataController.attackAble;

    }

}

public class SkillTransition : RangeTransition
{

    public SkillTransition(float range, Transform transform) : base(range, transform)
    {

        dataController = transform.GetComponent<UnitDataController>();
        targetLayer = dataController.targetLayer;

    }

    private UnitDataController dataController;



    public override bool ChackTransition()
    {

        return base.ChackTransition() && dataController.skillAble;

    }

}