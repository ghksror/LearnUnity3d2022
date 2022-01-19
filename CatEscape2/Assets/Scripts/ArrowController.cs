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
        //Init���� �ʰ� ȣ���
    }   

    public void Init(float speed, Vector3 initPos)
    {
        //Start���� ���� ȣ��� 
        this.speed = speed;
        this.transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {

        //����
        var dir = Vector2.down;  //(0,-1)

        //���� *�ӵ�
        var movement = dir * this.speed * Time.deltaTime;

        this.transform.Translate(movement);

        if (this.transform.position.y <= -4.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
