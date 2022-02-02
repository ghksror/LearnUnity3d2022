using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;  //�����ǹ�������Ʈ�� 3���� ��������Ʈ������������

    private float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize*2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Scrolling();
    }

    private void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    private void Scrolling()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 10, 0);
        }
    }
}
