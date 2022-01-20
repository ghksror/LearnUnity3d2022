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
        //�����̽��� ������ �����Ѵ�.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(Vector2.up * this.jumpForce);
        }

        // �¿� ȭ��ǥ �Է½� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; //GetKey = �������ִµ��ȿ�, GetKeyDown = ��������
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x); //Abs = ���밪 , velocity.x x���� �ӵ�

        //���ǵ� ����
        if ( speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }


        //�����̴� ���⿡ ���� �����Ѵ�.
        if(key != 0)
        {
            this.transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ��ش�.
        this.animator.speed = speedx / 2.0f;


    }
}
