using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RealMonsterController : MonoBehaviour
{
    private Animator anim;
    private Coroutine routine;

    public float maxhp = 10.0f;
    public float hp;
    public UnityAction OnDieAction;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.hp = this.maxhp;
    }

    public void Hit(float damage)
    {
        this.anim.Play("GetHit", -1, 0);  //���� Hit �ִϸ��̼�
        this.hp -= damage;

        if (this.hp <= 0)
        {
            this.Die();
        }
    }
    private void Die()
    {
        if (this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.DieForSec());
    }
    private IEnumerator DieForSec()
    {
        this.anim.Play("Die", -1, 0);    //���� Die �ִϸ��̼�
        yield return new WaitForSeconds(0.9f);
        Debug.Log("Die!");
        Destroy(this.gameObject);
    }
}
