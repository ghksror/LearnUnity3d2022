using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public enum eDir
    {
        LEFT = 1, RIGHT = -1
    }

    public eDir Dir;
    public float atten = 0.96f;
    public float initRotSpeed = 10.0f;
    float rotSpeed = 0; //회전 속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //왼쪽마우스를 클릭하면
        {
            this.rotSpeed = initRotSpeed *(int)Dir; //회전속도를 설정
        }

        //룰렛을 회전한다.(매 프레임마다)
        transform.Rotate(0, 0, this.rotSpeed);

        //룰렛을 감속
        this.rotSpeed *= this.atten;

    }


}
