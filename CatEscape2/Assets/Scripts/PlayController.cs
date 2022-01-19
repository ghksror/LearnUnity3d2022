using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform leftBoundaryPoint;
    public Transform rightBoundaryPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

}
