using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour
{
    private float starspeed;
    private Vector3 starPos;
    private float rotSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.starPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 endPos = Input.mousePosition;
            float Length = endPos.y - this.starPos.y;

            this.starspeed = (Length / 25.0f) * Time.deltaTime;
            this.rotSpeed = Length * Time.deltaTime;
        }
        transform.Rotate(new Vector3(0, 0, this.rotSpeed));
        transform.Translate(new Vector3(0, this.starspeed, 0), Space.World);
        this.starspeed *= 0.99f;
    }
}
