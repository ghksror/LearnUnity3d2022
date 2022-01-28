using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain : MonoBehaviour
{
    public MonsterController slime;
    // Start is called before the first frame update
    void Start()
    {
        this.slime = this.GetComponent<MonsterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���� ���콺 ��ư Ŭ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���̸� ����
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 2.5f);
            RaycastHit hit;// hit�� �浹 ������ �Ҵ�
            if(Physics.Raycast(ray , out hit, 1000f))//Collider�� �浹�Ѵٸ�
            {
                Debug.Log(hit.collider.gameObject.name);//�浹�������� collider�� ���ӿ�����Ʈ �̸��� ���
                
                if(hit.collider.tag == "Monster")  //�浹�������� �ݶ��̴��� �±װ� ���Ϳ� ���ٸ�...
                {
                    var monster = hit.collider.gameObject.GetComponent<MonsterController>(); //�� �ݶ��̴��� �������ִ� ���� ��Ʈ��������Ʈ�� ������ monster�ν��Ͻ��� ������ ����.
                    Debug.Log(monster.id); //���� ��Ʈ�ѿ� �ִ� id�� ���
                }
            }

            

        }
    }
}
