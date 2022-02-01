using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemys; //적기가 총 3종류니 배열사용
    public Transform[] spawnPoints; //적기 생성위치도 배열로 나눠서 랜덤으로 소환

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f); //최소값 ~ 최대값 사이로 실행
            curSpawnDelay = 0; //적 기 리스폰후에는 꼭 딜레이를 다시 0으로 초기화
        }
    }

    private void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemys[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation);
    }


}
