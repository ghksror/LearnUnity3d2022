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
        //스와이프 길이를 구한다
        if (Input.GetMouseButtonDown(0))
        {
            //마우스를 클릭한 좌표
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //마우스 버튼에서 손가락을 떼었을 때 좌표
            var endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;

            //스와이프 길이를 처음 속도로 변환한다.
            this.speed = swipeLength / 500.0f;

            // 효과음을 재생한다.
            GetComponent<AudioSource>().Play();
        }
        /*if (Input.GetMouseButtonDown(0))
        {  //마우스 왼쪽버튼 누르면 
            this.speed = 0.2f;  //초기속도를 설정 
        }*/

        //GameObject go = this.gameObject;
        //Transform trans = go.GetComponent<Transform>();
        //trans.Translate(this.speed, 0, 0); //x축으로 이동한다 

        //Transform trans = this.GetComponent<Transform>();
        //trans.Translate(this.speed, 0, 0); //x축으로 이동한다 

        this.transform.Translate(this.speed, 0, 0); //x축으로 이동한다 위와 동일 위쪽은 예전방법

        this.speed *= 0.96f;    //감속한다 
    }
}
