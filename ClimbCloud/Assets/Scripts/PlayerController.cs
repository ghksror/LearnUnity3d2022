using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;
    public float jumpForce = 680f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //스페이스바 누르면 점프한다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(Vector2.up * this.jumpForce);
        }

        // 좌우 화살표 입력시 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; //GetKey = 누르고있는동안에, GetKeyDown = 눌렀을때
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x); //Abs = 절대값 , velocity.x x축의 속도

        //스피드 제한
        if ( speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }


        //움직이는 방향에 따라 반전한다.
        if(key != 0)
        {
            this.transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 속도에 맞춰 애니메이션 속도를 바꿔준다.
        this.animator.speed = speedx / 2.0f;


    }
}
