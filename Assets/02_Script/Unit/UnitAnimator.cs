using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{

    private readonly int ATTACK_HASH = Animator.StringToHash("Attack");
    private readonly int SKILL_HSAH = Animator.StringToHash("Skill");
    private readonly int ISMOVE_HASH = Animator.StringToHash("IsMove");
    private readonly int DIE_HASH = Animator.StringToHash("Die");
    private readonly int ATTACKEND_HASH = Animator.StringToHash("AttackEnd");
    private readonly int SKILLEND_HASH = Animator.StringToHash("SkillEnd");

    private Animator animator;
    private bool isDie;

    public event Action OnAttackAnimeEnd;
    public event Action OnSkillAnimeEnd;
    public event Action OnDieAnimeEnd;
    public event Action OnAttack;
    public event Action OnSkill;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        OnDieAnimeEnd += () => Destroy(transform.root.gameObject);

    }

    public void OnAttackAnimeEndInvoke()
    {

        animator.SetTrigger(ATTACKEND_HASH);
        OnAttackAnimeEnd?.Invoke();

    }

    public void OnSkillAnimeEndInvoke()
    {

        animator.SetTrigger(SKILLEND_HASH);
        OnSkillAnimeEnd?.Invoke();

    }

    public void OnDieAnimeEndInvoke()
    {

        OnDieAnimeEnd?.Invoke();

    }

    public void OnSkillInvoke()
    {

        if (isDie) return;

        OnSkill?.Invoke();

    }

    public void OnAttackInvoke()
    {

        if(isDie) return;

        OnAttack?.Invoke();

    }

    public void SetIsMove(bool isMove)
    {

        if (isDie) return;

        animator.SetBool(ISMOVE_HASH, isMove);

    }

    public void SetDie()
    {

        if (isDie) return;

        isDie = true;
        animator.SetTrigger(DIE_HASH);

    }

    public void SetAttack()
    {

        if (isDie) return;

        animator.ResetTrigger(ATTACKEND_HASH);
        animator.SetTrigger(ATTACK_HASH);

    }

    public void SetSkill()
    {

        if (isDie) return;

        animator.ResetTrigger(SKILLEND_HASH);
        animator.SetTrigger(SKILL_HSAH);

    }

}
