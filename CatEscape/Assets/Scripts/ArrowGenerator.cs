using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;      //�ð��� ���� ��Ű�µ� ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;  //�� ������ ���� ����ð��� ������Ų��.
        if (this.delta > this.span)    //1.0f���� ũ�ٸ�...
        {
            this.delta = 0;

            GameObject go = Instantiate<GameObject>(this.arrowPrefab);   //�������� �ν��Ͻ�ȭ
            //GameObject go = Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);

        }

    }
}
