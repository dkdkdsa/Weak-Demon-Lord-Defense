using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Debug")]
public class DebugSkill : SkillRoot
{
    public override void DoSkill(Transform origin, Transform target, LayerMask targetMask)
    {

        Debug.Log("Debug!!");

    }

}
