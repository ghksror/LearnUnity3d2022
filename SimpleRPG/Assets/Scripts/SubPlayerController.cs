using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubPlayerController : MonoBehaviour
{
    public enum eAttackType
    {
        None,
        ShootAttack,
    }
    public float damage = 5.0f;
    public Transform a;
    public float speed = 1.0f;
    public Transform monster;
    public Transform firepoint;
    public float attackRange = 5.0f;

    public UnityAction<eAttackType> OnAttackImpact;
    public UnityAction<eAttackType> OnAttackComplete;
    private Animator anim;
    private Coroutine routine;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();

    }

    public void PlayerAttack()
    {
        if (this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.AttackRoutine());
    }
    public void PlayerMove()
    {
        if (this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            this.anim.SetTrigger("Run");  //달리기 애니메이션
            this.transform.LookAt(a.position);
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);

            var dis = Vector3.Distance(this.a.position, this.transform.position);
            if (dis < 0.1f)
            {
                break;
            }
            yield return null;
        }
        Debug.Log("이동 완료!");
        this.anim.ResetTrigger("Run");  //달리기 애니메이션
        this.anim.SetTrigger("Idle");   //기본동작 애니메이션
    }

    private IEnumerator AttackRoutine()
    {
        this.transform.LookAt(monster.position);
        this.anim.Play("Attack01", -1, 0);  //Shoot애니메이션
        Ray ray = new Ray(this.firepoint.position, this.transform.forward * this.attackRange);
        Debug.DrawRay(ray.origin, ray.direction * this.attackRange, Color.red, 5f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, this.attackRange))
        {
            Debug.Log(hit.collider.gameObject);
            Debug.Log("공격!");
            
        }
        yield return new WaitForSeconds(0.833f);
        this.OnAttackImpact(eAttackType.ShootAttack);

        this.Idle();
    }
    public void Idle()
    {
        this.anim.Play("Idle_Battle", -1, 0);  //기본동작 애니메이션
    }
}
