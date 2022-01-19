using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform leftBoundaryPoint;
    public Transform rightBoundaryPoint;
    public float radius = 1f;
    public System.Action<float> OnHit;
    public System.Action OnDie;
    public float maxHp;
    [HideInInspector]
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        //this.hp = this.maxHp;
    }
    //Init ���� ���� start ���� �ʿ����
    public void Init(float maxHp, Transform leftBoundary, Transform rightBoundary, Vector3 InitPos)
    {
        this.maxHp = maxHp;
        this.hp = maxHp;
        this.leftBoundaryPoint = leftBoundary;
        this.rightBoundaryPoint = rightBoundary;
        this.transform.position = InitPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMain.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //var dir = new Vector2(-1, 0);
            //var dir = Vector2.left;

            //���� * �ӵ� * �ð� (�� �����Ӹ��� timetodeltatime���� �������� ��������)
            //���� * �ӵ� 
            //���� * ����
            this.transform.Translate( Vector2.left*this.speed); //���������� ��� �������� �� ������ �����ϰ��ΰ�...
            CheckBoundary();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector2.right * this.speed);
            CheckBoundary();
        }

    }

    private void CheckBoundary()
    {
        var pos = this.transform.position;
        pos.x = Mathf.Clamp(this.transform.position.x, this.leftBoundaryPoint.position.x, this.rightBoundaryPoint.position.x);
        this.transform.position = pos;
    }

    public void Hit(int damage)
    {
        //ü�� ����
        this.hp -= damage;
        if ( hp <= 0)
        {
            this.hp = 0;
        }

        this.OnHit(this.GetPercentageByHp());

        if ( hp <= 0)
        {
            this.OnDie();
        }
    }

    private float GetPercentageByHp()
    {
        return this.hp / this.maxHp;
    }



}
