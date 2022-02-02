using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;
    public GameObject enemyCPrefab;
    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;
    public GameObject playBulletAPrefab;
    public GameObject playBulletBPrefab;
    public GameObject enemyBulletAPrefab;
    public GameObject enemyBulletBPrefab;

    private GameObject[] enemyA;
    private GameObject[] enemyB;
    private GameObject[] enemyC;

    private GameObject[] itemCoin;
    private GameObject[] itemPower;
    private GameObject[] itemBoom;

    private GameObject[] playerBulletA;
    private GameObject[] playerBulletB;
    private GameObject[] enemyBulletA;
    private GameObject[] enemyBulletB;

    private GameObject[] targetPool;

    private void Awake()
    {
        enemyA = new GameObject[10];
        enemyB = new GameObject[10];
        enemyC = new GameObject[10];

        itemCoin = new GameObject[20];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        playerBulletA = new GameObject[100];
        playerBulletB = new GameObject[100];
        enemyBulletA = new GameObject[100];
        enemyBulletB = new GameObject[100];

        Generate();
    }

    private void Generate()
    {
        for(int index=0; index<enemyA.Length; index++)
        {
            enemyA[index] = Instantiate(enemyAPrefab);
            enemyA[index].SetActive(false);
        }

        for (int index = 0; index < enemyB.Length; index++)
        {
            enemyB[index] = Instantiate(enemyBPrefab);
            enemyB[index].SetActive(false);
        }

        for (int index = 0; index < enemyC.Length; index++)
        {
            enemyC[index] = Instantiate(enemyCPrefab);
            enemyC[index].SetActive(false);
        }

        for (int index = 0; index < itemCoin.Length; index++)
        {
            itemCoin[index] = Instantiate(itemCoinPrefab);
            itemCoin[index].SetActive(false);
        }

        for (int index = 0; index < itemPower.Length; index++)
        {
            itemPower[index] = Instantiate(itemPowerPrefab);
            itemPower[index].SetActive(false);
        }

        for (int index = 0; index < itemBoom.Length; index++)
        {
            itemBoom[index] = Instantiate(itemBoomPrefab);
            itemBoom[index].SetActive(false);
        }

        for (int index = 0; index < playerBulletA.Length; index++)
        {
            playerBulletA[index] = Instantiate(playBulletAPrefab);
            playerBulletA[index].SetActive(false);
        }

        for (int index = 0; index < playerBulletB.Length; index++)
        {
            playerBulletB[index] = Instantiate(playBulletBPrefab);
            playerBulletB[index].SetActive(false);
        }

        for (int index = 0; index < enemyBulletA.Length; index++)
        {
            enemyBulletA[index] = Instantiate(enemyBulletAPrefab);
            enemyBulletA[index].SetActive(false);
        }

        for (int index = 0; index < enemyBulletB.Length; index++)
        {
            enemyBulletB[index] = Instantiate(enemyBulletBPrefab);
            enemyBulletB[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type) //오브젝트 풀에 접근할수 있는 함수 생성(오브젝트를 반환)
    {
        switch (type)
        {
            case "EnemyA":
                targetPool = enemyA;
                break;
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyC":
                targetPool = enemyC;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "PlayerBulletA":
                targetPool = playerBulletA;
                break;
            case "PlayerBulletB":
                targetPool = playerBulletB;
                break;
            case "EnemyBulletA":
                targetPool = enemyBulletA;
                break;
            case "EnemyBulletB":
                targetPool = enemyBulletB;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            //비 활성화 되어있다면 활성화 시켜주세요라는뜻
            if (targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

}
