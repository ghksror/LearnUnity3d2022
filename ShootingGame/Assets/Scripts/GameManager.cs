using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] enemys; //���Ⱑ �� 3������ �迭���
    public Transform[] spawnPoints; //���� ������ġ�� �迭�� ������ �������� ��ȯ

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage; //������ �̹����� 3���⶧���� �迭
    public GameObject gameOverSet;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f); //�ּҰ� ~ �ִ밪 ���̷� ����
            curSpawnDelay = 0; //�� �� �������Ŀ��� �� �����̸� �ٽ� 0���� �ʱ�ȭ
        }

        //Score UI
        PlayerController playerLogic = player.GetComponent<PlayerController>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score); //{0:n0} = ���ڸ����� ��ǥ�� �����ִ� ���� ���

    }

    private void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 9);
        GameObject enemy = Instantiate(enemys[ranEnemy],
                                       spawnPoints[ranPoint].position,
                                       spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();

        EnemyController enemyLogic = enemy.GetComponent<EnemyController>();
        enemyLogic.player = player;
        if(ranPoint == 6 || ranPoint == 8)
        {
            enemy.transform.Rotate(Vector3.back*90);
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
        }
        else if(ranPoint == 5 || ranPoint == 7)
        {
            enemy.transform.Rotate(Vector3.forward * 90);
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
        }
        else
        {
            rigid.velocity = new Vector2(0, enemyLogic.speed*(-1));
        }

    }
    public void UpdateLifeIcon(int life)
    {
        //UI Life Init Disable �ϴ� ���ٰ�
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }
        //UI Life Active  �����ִ� ������ŭ �ٽ� Ų��.
        for (int index=0; index< life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 2f);
    }

    private void RespawnPlayerExe()
    {
        player.transform.position = Vector3.down * 4f;
        player.SetActive(true);

        PlayerController playerLogic = player.GetComponent<PlayerController>();
        playerLogic.isHit = false;
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        SceneManager.LoadScene("GameScene");
    }

}
