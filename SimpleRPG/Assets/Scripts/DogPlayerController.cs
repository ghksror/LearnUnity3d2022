using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPlayerController : MonoBehaviour
{
    private Animator anim;
    private float speed = 1.5f;
    private Coroutine routine;

    // Start is called before the first frame update
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (this.isMove)
        {
            this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
            var distance = Vector3.Distance(this.transform.position, this.tpos);
            if(distance <= 0.20f)
            {
                this.anim.ResetTrigger("Run");
                this.anim.SetTrigger("Idle");
                this.isMove = false;
            }
        }

    }*/
    /*public void Move(Vector3 tpos)   //코루틴으로 수정
    {
        
        this.anim.SetTrigger("Run");
        this.tpos = tpos;
        this.transform.LookAt(tpos);
        this.isMove = true;
    }*/

    public void Move(Vector3 tpos)
    {
        if(this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.MoveRoutine(tpos));
    }

    private IEnumerator MoveRoutine(Vector3 tpos)
    {
        
        this.anim.SetTrigger("Run");
        this.transform.LookAt(tpos);
        while (true)
        {
            var distance = Vector3.Distance(this.transform.position,tpos);
            if (distance <= 0.20f)
            {
                break;
            }
            this.transform.Translate(Vector3.forward * this.speed * Time.deltaTime);
            yield return null;
        }
        //move complete
        this.anim.ResetTrigger("Run");
        this.anim.SetTrigger("Idle");
    }

}
