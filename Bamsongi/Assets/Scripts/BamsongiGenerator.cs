using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //밤송이 프리팹 인스턴스화
            GameObject bamsongi = Instantiate(this.bamsongiPrefab) as GameObject;
            //bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000));

            //Ray 책 380페이지 매우 중요 (Ray = 콜라이더가 적용된 오브젝트와 충돌을 감지가능)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //스크린 좌표를 월드좌표롤 변경한 후 Ray를 쏜다.
            //Debug.DrawRay(ray.origin, ray.direction * 1000f , Color.red, 1.0f); //Ray 를 화면에 레이저로 표시
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);

        }

    }
}
