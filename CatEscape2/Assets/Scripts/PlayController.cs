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
    //Init 먼저 실행 start 내용 필요없음
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

            //방향 * 속도 * 시간 (매 프레임마다 timetodeltatime으로 동적으로 설정가능)
            //방향 * 속도 
            //방향 * 유닛
            this.transform.Translate( Vector2.left*this.speed); //누를때마다 어느 방향으로 몇 유닛을 움직일것인가...
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
        //체력 감소
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
