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
        // 왼쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // <-키를 누른순간(1번) , .GetKey = 누르고있는동안 , .GetKeyup = 키를 뗀 순간
        {
            transform.Translate(-3, 0, 0); // 왼쪽으로(x축 <<<쪽으로) '3' 만큼 움직인다.
            if (this.transform.position.x <= -8.0f)
            {
                var pos = this.transform.position;
                pos.x = -8.0f;
                this.transform.position = pos;
            }
        }

        // 오른쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.RightArrow)) // ->키를 눌렀을때(1번)
        {
            transform.Translate(3, 0, 0); // 오른쪽으로(x축 >>>쪽으로) '3' 만큼 움직인다.
            if (this.transform.position.x >= 8.0f)
            {
                var pos = this.transform.position;
                pos.x = 8.0f;
                this.transform.position = pos;
            }
        }

    }
}
