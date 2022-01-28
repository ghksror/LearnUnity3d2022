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
        if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼 클릭시
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //레이를 만듬
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 2.5f);
            RaycastHit hit;// hit에 충돌 정보가 할당
            if(Physics.Raycast(ray , out hit, 1000f))//Collider와 충돌한다면
            {
                Debug.Log(hit.collider.gameObject.name);//충돌정보에서 collider의 게임오브젝트 이름을 출력
                
                if(hit.collider.tag == "Monster")  //충돌정보에서 콜라이더의 태그가 몬스터와 같다면...
                {
                    var monster = hit.collider.gameObject.GetComponent<MonsterController>(); //그 콜라이더가 가지고있는 몬스터 컨트롤컴포넌트의 정보를 monster인스턴스에 정보를 부착.
                    Debug.Log(monster.id); //몬스터 컨트롤에 있는 id를 출력
                }
            }

            

        }
    }
}
