using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class HeroController : MonoBehaviour
{
    public enum eAttackType
    {
        None,
        Attack01,
        Attack02,
    }

    private Animator anim;
    private Coroutine routine;
    public float attackdelay = 2.0f;
    public float damage;
    private float hp;
    public float maxHP;
    public float AttackPoint;


    private MonsterController target;
    public UnityAction<eAttackType> OnAttackImpact;
    private UnityAction OnMoveComplete;
    public Transform fxPivot;
    public UnityAction<eAttackType> OnAttackComplete;


    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.hp = this.maxHP;
        this.OnMoveComplete = () =>
        {
            this.Attack(this.target);
        };

    }

    public void Attack(MonsterController target)
    {
        this.target = target;
        if(this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.WaitForIdleAnimation());
    }

    private IEnumerator WaitForIdleAnimation()
    {
        while (true)
        {
            if (HasTarget())
            {
                if (this.CanAttack())
                {
                    this.anim.Play("Attack01", -1, 0); //"Attack01"로 끝내면 한번실행하고
                                                       //더이상 실행이안된다,리셋이안됐기때문
                    yield return new WaitForSeconds(0.483f);
                    //타겟에게 피해를 입힙니다.
                    this.target.Hit(this.damage);

                    //이벤트 발생
                    this.OnAttackImpact(eAttackType.Attack01);
                    yield return new WaitForSeconds(0.35f);

                    this.Idle();

                    this.OnAttackComplete(eAttackType.Attack01);
                }
                else
                {
                    this.routine = StartCoroutine(this.MoveToTarget());
                    yield break;
                }
            }
            else
            {
                this.Idle();
                break;
            }

            if (this.HasTarget())
            {
                if (this.CanAttack())
                {
                    this.anim.Play("Attack02", -1, 0);
                    yield return new WaitForSeconds(0.349f);
                    this.target.Hit(this.damage);
                    //이벤트 발생
                    this.OnAttackImpact(eAttackType.Attack02);
                    yield return new WaitForSeconds(0.484f);    
                    
                    this.Idle();
                    //Debug.Log("대기!");
                    yield return new WaitForSeconds(attackdelay);

                    this.OnAttackComplete(eAttackType.Attack02);
                }
                else
                {
                    this.routine = StartCoroutine(this.MoveToTarget());
                    yield break;
                }
            }
            else
            {
                this.Idle();
                break;
            }
            
        }
    }    

    private IEnumerator MoveToTarget()
    {
        this.transform.LookAt(this.target.transform);

        this.anim.Play("RunForwardBattle", -1, 0);

        while (true)
        {
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);

            if (CanAttack())
            {

                this.OnMoveComplete();
                yield break;
            }

            yield return null;
        }
    }

    public bool CanAttack()
    {
        var distance = Vector3.Distance(this.target.transform.position, this.transform.position);
        return this.AttackPoint >= distance;
    }

    public void Idle()
    {
        this.anim.Play("Idle_Battle", -1, 0);
    }
    public void SetTarget(MonsterController target)
    {
        this.target = target;
    }

    private bool HasTarget()
    {
        return this.target != null;
    }




}
