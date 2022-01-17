using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    //float starspeed = 0;
    float rotSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotSpeed = 5.0f;
        /*if (Input.GetMouseButtonDown(0))
        {
            this.starspeed = 0.2f;
        }

        transform.Translate(this.starspeed,0, 0);*/
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        this.transform.Rotate(0, 0, this.rotSpeed);
    }
}
