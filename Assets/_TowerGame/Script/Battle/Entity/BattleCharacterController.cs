using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BattleCharacterController : MonoBehaviour
{
    private float startTime;
    private float distance;
    private bool isMoving = false;
    private Transform defaultLookAt;
    private List<ICharacterActionListener> listeners = new List<ICharacterActionListener>();

    protected Vector3 startPosition;
    protected Animator animator;
    protected Transform targetTransform;
    protected bool resetPosition = false;

    public UnitData Data { get; set; }
    public ActionData SkillToPerform { get; set; }
    public bool IsActing { get; private set; }
    public BattleCharacterController Target { get; set; }
    // todo better handling of this
    public int CharacterID { get; set; }
    public BattleSystem BattleSystemRef { get; set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(IdleTimer());
    }

    public void AddListener(ICharacterActionListener listener)
    {
        listeners.Add(listener);
    }
    
    public void RemoveListener(ICharacterActionListener listener)
    {
        listeners.Remove(listener);
    }

    private void CallListeners(ActionType actionType, float damage = 0)
    {
        List<ICharacterActionListener> tmp = new List<ICharacterActionListener>(listeners);
        foreach (var listener in tmp)
        {
            switch(actionType)
            {
                case ActionType.DAMAGE:
                    listener.OnCharacterTakeDamage(this, damage);
                    break;
                case ActionType.DEATH:
                    listener.OnCharacterDeath(this);
                    break;
                case ActionType.RESET:
                    listener.OnCharacterPositionReset(this);
                    break;
            }
        }
    }


    public void SetDefaultLookAt(Transform target)
    {
        defaultLookAt = target;
        transform.LookAt(defaultLookAt);
    }

    internal void PerformSkill(ProcessedActionData skillToPerform)
    {
        SkillToPerform = skillToPerform.ActionData;
        //var character = battleSystem.GetRandomCharacter(GetTargetType());
        if (skillToPerform.Target == null)
        {
            Target = this;
        }
        else
        {
            Target = skillToPerform.Target;
        }
        targetTransform = Target.transform;
        IsActing = true;
        if (SkillToPerform.MyActionTypeTag == ActionTypeTag.RANGED)
        {
            animator.SetBool("isRanged", true);
            StartMovement(false);
        }
        else
        {
            animator.SetBool("isRanged", false);
        }
        animator.SetInteger("animID", SkillToPerform.AnimID);
    }

    protected abstract TargetGroup GetTargetType();

    public void ResetCharacter(bool hasResetAnim)
    {
        if (hasResetAnim)
        {
            resetPosition = true;
            Data.CurrentSpeed = 1;
            StartMovement(true);
        }
        else
        {
            transform.position = startPosition;
            EndAnim();
        }

    }
    protected void StartMovement(bool isReset)
    {
        isMoving = true;
        animator.SetBool("isMoving", isMoving);

        //enemi position
        startTime = Time.time;
        distance = Vector3.Distance(transform.position, (isReset ? startPosition : targetTransform.position));
    }

    private IEnumerator IdleTimer()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 20f));
        animator.SetInteger("idleVariation", (int)UnityEngine.Random.Range(0, 11));
        StartCoroutine(IdleTimer());
    }

    public void Hit()
    {
        Target.GetComponent<BattleCharacterController>().TakeDamage(SkillToPerform.Damage);
    }

    private void TakeDamage(float damage)
    {
        Data.CurrentLife -= damage;

        CallListeners(ActionType.DAMAGE, damage);

        if (Data.CurrentLife > 0)
        {
            animator.SetBool("isDamaged", true);
        } else
        {
            animator.SetBool("isDying", true);
            CallListeners(ActionType.DEATH);
        }
    }

    internal void EndAnim()
    {
        IsActing = false;
        resetPosition = false;
        animator.SetBool("isRanged", false);
        animator.SetInteger("animID", 0);
        SkillToPerform = null;
        transform.LookAt(defaultLookAt);
        CallListeners(ActionType.RESET);
    }

    protected virtual void Update()
    {
        if (isMoving)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * Data.CurrentSpeed; //todo

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / distance;
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, 
                (resetPosition ? startPosition : Target.transform.position), fractionOfJourney);
            transform.LookAt(Target.transform);
            //todo variable distance from target
            if ((!resetPosition && Vector3.Distance(transform.position, targetTransform.position) <= distance - (distance * 0.80)) 
                || (resetPosition && Vector3.Distance(transform.position, startPosition) <= 0.1f))
            {
                isMoving = false;
                animator.SetBool("isMoving", isMoving);
                if (resetPosition)
                    EndAnim();
            }
        }
    }
}

public enum TargetGroup
{
    HERO,
    MONSTER
}
