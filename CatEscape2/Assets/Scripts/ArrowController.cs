using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = 0.5f;
    public PlayController player;

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
        this.player = GameObject.FindObjectOfType<PlayController>();

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

        var radiusSum = this.player.radius + this.radius;
        var distance = Vector2.Distance(this.player.transform.position, this.transform.position);

        if (distance < radiusSum)
        {
            Destroy(this.gameObject);   //제거 
            Debug.Log("충돌!");
        }

    }
}
