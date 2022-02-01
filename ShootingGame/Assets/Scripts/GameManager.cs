using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemys; //���Ⱑ �� 3������ �迭���
    public Transform[] spawnPoints; //���� ������ġ�� �迭�� ������ �������� ��ȯ

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f); //�ּҰ� ~ �ִ밪 ���̷� ����
            curSpawnDelay = 0; //�� �� �������Ŀ��� �� �����̸� �ٽ� 0���� �ʱ�ȭ
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
