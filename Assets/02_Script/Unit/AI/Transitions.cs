using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTransition : TransitionRoot
{

    public RangeTransition(float range)
    {

        this.range = range;

    }

    public float range;
    public Transform target;

    public override bool ChackTransition()
    {
        throw new System.NotImplementedException();
    }
}