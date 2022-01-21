using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAGenerator : MonoBehaviour
{
    private float delta;
    private float span = 1.0f;
    public GameObject enemyAPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //적기프리팹 인스턴스화
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject enemyAGo = Instantiate<GameObject>(this.enemyAPrefab);
            float RandomPX = Random.Range(-2.2f, 2.2f);
            float PY = 5.7f;
            enemyAGo.transform.position = new Vector3(RandomPX, PY, 0);
        }

    }
}
