using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //�����Ӹ��� ������� ���Ͻ�Ų��
        this.transform.Translate(0, -0.1f, 0);

        //ȭ�� ������ ������ ������Ʈ�� �Ҹ��Ų��.
        if(this.transform.position.y < -5.0f)
        {
            Destroy(this.gameObject);
        }

        //�浹 ����
        Vector2 p1 = transform.position;              //ȭ��ǥ�� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position;  // �÷��̾��� �߽� ��ǥ
        
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        //Debug.LogFormat("{0},{1}", dir.normalized, d);  Ȯ���ϱ����� ����׷α�
        //float d = Vector2.Distance(p1, p2);  //���� ��
        
        float r1 = 0.5f;                               // ȭ���� �ݰ�
        float r2 = 1.0f;                               // �÷��̾��� �ݰ�

        if(d<r1 + r2)
        {
            // ���� ��ũ��Ʈ�� �÷��̾�� ȭ���� �浹�ߴٰ� �����Ѵ�.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();


            //�浹�� ���� ȭ���� �����
            Debug.Log("�浹�ߴ�.");
            Destroy(this.gameObject);
        }


    }
}
