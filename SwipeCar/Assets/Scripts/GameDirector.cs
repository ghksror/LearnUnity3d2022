using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�� �̿��ϴµ� �ʿ�

public class GameDirector : MonoBehaviour
{
    private GameObject car;
    private GameObject flag;
    private GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        
        if(length >= 0)
        {
            this.distance.GetComponent<Text>().text = "��ǥ ��������" + length.ToString("F2") + "m";  //�Ʒ��� �����Ѷ�

            /*Text txtDistance = this.distance.GetComponent<Text>();
            txtDistance.text = string.Format("��ǥ�������� {0}m", length.ToString("F2"));*/

        }
        else
        {
            this.distance.GetComponent<Text>().text = "Game Over!";
        }
        

    }
}
