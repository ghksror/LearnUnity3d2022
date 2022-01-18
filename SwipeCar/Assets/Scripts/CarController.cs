using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Vector3 startPos;
    // Update is called once per frame
    void Update()
    {
        //�������� ���̸� ���Ѵ�
        if (Input.GetMouseButtonDown(0))
        {
            //���콺�� Ŭ���� ��ǥ
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //���콺 ��ư���� �հ����� ������ �� ��ǥ
            var endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            //�������� ���̸� ó�� �ӵ��� ��ȯ�Ѵ�.
            this.speed = swipeLength / 500.0f;

            // ȿ������ ����Ѵ�.
            GetComponent<AudioSource>().Play();
        }
        /*if (Input.GetMouseButtonDown(0))
        {  //���콺 ���ʹ�ư ������ 
            this.speed = 0.2f;  //�ʱ�ӵ��� ���� 
        }*/

        //GameObject go = this.gameObject;
        //Transform trans = go.GetComponent<Transform>();
        //trans.Translate(this.speed, 0, 0); //x������ �̵��Ѵ� 

        //Transform trans = this.GetComponent<Transform>();
        //trans.Translate(this.speed, 0, 0); //x������ �̵��Ѵ� 

        this.transform.Translate(this.speed, 0, 0); //x������ �̵��Ѵ� ���� ���� ������ �������

        this.speed *= 0.96f;    //�����Ѵ� 
    }
}
