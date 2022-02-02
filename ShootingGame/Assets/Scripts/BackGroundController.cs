using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;  //각각의배경오브젝트가 3개의 스프라이트를가지고있음

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
