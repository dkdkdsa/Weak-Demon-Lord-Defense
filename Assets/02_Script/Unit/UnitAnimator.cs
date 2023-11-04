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

        OnAttackAnimeEnd?.Invoke();

    }

    public void OnSkillAnimeEndInvoke()
    {

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

        animator.SetBool(ISMOVE_HASH, isMove);

    }

    public void SetDie()
    {

        isDie = true;
        animator.SetTrigger(DIE_HASH);

    }

    public void SetAttack()
    {

        animator.SetTrigger(ATTACK_HASH);

    }

    public void SetSkill()
    {

        animator.SetTrigger(SKILL_HSAH);

    }

}
