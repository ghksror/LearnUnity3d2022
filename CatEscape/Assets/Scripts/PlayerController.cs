using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
        if (this.transform.position.x <= -8.0f)
        {
            var pos = this.transform.position;
            pos.x = -8.0f;
            this.transform.position = pos;
        }
    }

    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
        if (this.transform.position.x >= 8.0f)
        {
            var pos = this.transform.position;
            pos.x = 8.0f;
            this.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ȭ��ǥ�� ������ ��
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // <-Ű�� ��������(1��) , .GetKey = �������ִµ��� , .GetKeyup = Ű�� �� ����
        {
            transform.Translate(-3, 0, 0); // ��������(x�� <<<������) '3' ��ŭ �����δ�.
            if (this.transform.position.x <= -8.0f)
            {
                var pos = this.transform.position;
                pos.x = -8.0f;
                this.transform.position = pos;
            }
        }

        // ������ ȭ��ǥ�� ������ ��
        if (Input.GetKeyDown(KeyCode.RightArrow)) // ->Ű�� ��������(1��)
        {
            transform.Translate(3, 0, 0); // ����������(x�� >>>������) '3' ��ŭ �����δ�.
            if (this.transform.position.x >= 8.0f)
            {
                var pos = this.transform.position;
                pos.x = 8.0f;
                this.transform.position = pos;
            }
        }

    }
}
