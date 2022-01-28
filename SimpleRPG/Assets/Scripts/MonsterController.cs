using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MonsterController : MonoBehaviour
{
    public int id;
    Coroutine routine;
    private Animator anim;
    public float maxhp;
    private float hp;
    public UnityAction OnDieAction;

    // Start is called before the first frame update

    void Start()
    {
        this.hp = this.maxhp;
        this.anim = this.GetComponent<Animator>();

    }

    public void Hit(float damage)
    {
        this.hp -= damage;

        if(this.hp <= 0)
        {
            this.hp = 0;
            //die
            this.Die();

        }
        else
        {
            if (this.routine != null)
            {
                StopCoroutine(this.routine);
            }
            this.routine = StartCoroutine(this.GetHitAnimation());
        }
    }
    private IEnumerator GetHitAnimation()
    {
        
        this.anim.Play("GetHit", -1, 0);

        yield return new WaitForSeconds(0.833f);

        this.anim.Play("IdleNormal", -1, 0);

    }
    private void Die()
    {
        Debug.Log("Die!");
        this.OnDieAction();

        //play animation
        this.anim.Play("Die", -1, 0);
        //wait for die animation
        this.StartCoroutine(this.WaitForSec(1.33f, () =>
        {
            //destroy
            Destroy(this.gameObject);
        }));

    }

    private IEnumerator WaitForSec(float sec, System.Action callback)
    {
        yield return new WaitForSeconds(sec);
        callback();
    }

    public bool IsDie()
    {
        return this.hp <= 0;
    }

}
