using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillRoot : ScriptableObject
{

    public float skillValue;

    public abstract void DoSkill(Transform origin, Transform target, LayerMask targetMask);

}
