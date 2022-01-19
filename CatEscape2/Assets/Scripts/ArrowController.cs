using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        //Init보다 늦게 호출됨
    }   

    public void Init(float speed, Vector3 initPos)
    {
        //Start보다 먼저 호출됨 
        this.speed = speed;
        this.transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {

        //방향
        var dir = Vector2.down;  //(0,-1)

        //방향 *속도
        var movement = dir * this.speed * Time.deltaTime;

        this.transform.Translate(movement);

        if (this.transform.position.y <= -4.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
