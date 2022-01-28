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
            this.anim.SetTrigger("Run");  //�޸��� �ִϸ��̼�
            this.transform.LookAt(a.position);
            this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);

            var dis = Vector3.Distance(this.a.position, this.transform.position);
            if (dis < 0.1f)
            {
                break;
            }
            yield return null;
        }
        Debug.Log("�̵� �Ϸ�!");
        this.anim.ResetTrigger("Run");  //�޸��� �ִϸ��̼�
        this.anim.SetTrigger("Idle");   //�⺻���� �ִϸ��̼�
    }

    private IEnumerator AttackRoutine()
    {
        this.transform.LookAt(monster.position);
        this.anim.Play("Attack01", -1, 0);  //Shoot�ִϸ��̼�
        Ray ray = new Ray(this.firepoint.position, this.transform.forward * this.attackRange);
        Debug.DrawRay(ray.origin, ray.direction * this.attackRange, Color.red, 5f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, this.attackRange))
        {
            Debug.Log(hit.collider.gameObject);
            Debug.Log("����!");
            
        }
        yield return new WaitForSeconds(0.833f);
        this.OnAttackImpact(eAttackType.ShootAttack);

        this.Idle();
    }
    public void Idle()
    {
        this.anim.Play("Idle_Battle", -1, 0);  //�⺻���� �ִϸ��̼�
    }
}
