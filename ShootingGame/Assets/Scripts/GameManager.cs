using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] enemys; //적기가 총 3종류니 배열사용
    public Transform[] spawnPoints; //적기 생성위치도 배열로 나눠서 랜덤으로 소환

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage; //라이프 이미지가 3개기때문에 배열
    public GameObject gameOverSet;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f); //최소값 ~ 최대값 사이로 실행
            curSpawnDelay = 0; //적 기 리스폰후에는 꼭 딜레이를 다시 0으로 초기화
        }

        //Score UI
        PlayerController playerLogic = player.GetComponent<PlayerController>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score); //{0:n0} = 세자리마다 쉼표로 나눠주는 숫자 양식

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
        //UI Life Init Disable 일단 껏다가
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }
        //UI Life Active  남아있는 개수만큼 다시 킨다.
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
