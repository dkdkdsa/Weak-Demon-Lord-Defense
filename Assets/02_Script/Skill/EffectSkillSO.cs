using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/EffectSkill")]
public class EffectSkillSO : SkillRoot
{

    [SerializeField] private EffectSkill prefab;
    [SerializeField] private string skillName;

    public override void DoSkill(Transform origin, Transform target, LayerMask targetMask)
    {

        var com = origin.GetComponent<UnitDataController>();

        var txt = FAED.TakePool<TMP_Text>("SkillText", origin.position, Quaternion.Euler(45, 0, 0));
        txt.text = skillName;
        txt.transform.DOMoveY(origin.position.y + 3, 1f).OnComplete(() => Destroy(txt.gameObject));

        if(target != null)
        {

            var eft = Instantiate(prefab, target.position, Quaternion.identity);
            eft.Casting(skillValue + com.attackPower + com.extraAttack, targetMask);

        }

    }

}
