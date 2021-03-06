using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameObject player;
    private GameObject director;
    float span = 1.0f;
    float delta = 0;      //시간을 누적 시키는데 사용

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;  //매 프레임 마다 경과시간을 누적시킨다.
        if (this.delta > this.span)    //1.0f보다 크다면...
        {
            this.delta = 0;

            GameObject go = Instantiate<GameObject>(this.arrowPrefab);   //프리팹을 인스턴스화
            //GameObject go = Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);

        }

    }
}
