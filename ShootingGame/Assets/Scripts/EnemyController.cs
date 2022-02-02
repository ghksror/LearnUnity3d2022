using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    public float bulletSpeed = 4;
    public float speed;
    public float hp;
    public Sprite[] sprites; //일반, 히트상태 두개기때문에 배열로사용

    public float maxShotDelay;  //실제 딜레이
    public float curShotDelay;  //한발 쏜이후 충전되기까지의 딜레이

    public GameObject bulletAPrefab;
    public GameObject bulletBPrefab;
    public GameObject itemCoin;
    public GameObject itemPower;
    public GameObject itemBoom;
    public GameObject player;


    //Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        /*rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed; //Vector2인 이유는 릿지드바디2D이기때문*/
    }

    void Update()
    {
        
        Fire();
        Reload();
    }

    private void Fire()
    {
        if (curShotDelay < maxShotDelay)
        {
            return;
        }

        if(enemyName == "S")
        {
            GameObject bulletGo = Instantiate(bulletAPrefab, this.transform.position, this.transform.rotation);
            Rigidbody2D rigid = bulletGo.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - this.transform.position;
            rigid.AddForce(dirVec.normalized * bulletSpeed, ForceMode2D.Impulse);
        }
        else if (enemyName == "L")
        {
            GameObject bulletRGo = Instantiate(bulletBPrefab, this.transform.position + Vector3.right*0.3f, this.transform.rotation);
            Rigidbody2D rigidR = bulletRGo.GetComponent<Rigidbody2D>();
            Vector3 dirVecR = player.transform.position - (this.transform.position + Vector3.right * 0.3f);
            rigidR.AddForce(dirVecR.normalized * bulletSpeed, ForceMode2D.Impulse);

            GameObject bulletLGo = Instantiate(bulletBPrefab, this.transform.position + Vector3.left * 0.3f, this.transform.rotation);
            Rigidbody2D rigidL = bulletLGo.GetComponent<Rigidbody2D>();
            Vector3 dirVecL = player.transform.position - (this.transform.position + Vector3.left * 0.3f);
            rigidL.AddForce(dirVecL.normalized * bulletSpeed, ForceMode2D.Impulse);
        }


        curShotDelay = 0; //총알을 다 쐇으면 다시 장전을해야하므로 0으로초기화
    }

    private void Reload()
    {
        curShotDelay += Time.deltaTime;

    }

    public void OnHit(int damage)
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= damage;
        spriteRenderer.sprite = sprites[1]; //평소 스프라이트=0, 히트 스프라이트=1
        Invoke("ReturnSprite", 0.1f); //리턴스프라이트 메서드를 호출하고0.1초뒤에 호출해주세요라는의미 
        if(hp <= 0)
        {
            PlayerController playerLogic = player.GetComponent<PlayerController>();
            playerLogic.score += enemyScore;

            //Random Ratio Item Drop 적기가 터졌을때 랜덤확률로 아이템드랍
            int ran = Random.Range(0, 10);
            if(ran < 5)
            {
                //50%미드랍
                
            }
            else if (ran < 8)
            {
                //30%돈
                Instantiate(itemCoin, this.transform.position, itemCoin.transform.rotation);
            }
            else if (ran < 9)
            {
                //10%파워
                Instantiate(itemPower, this.transform.position, itemPower.transform.rotation);
            }
            else if (ran < 10)
            {
                //10%폭탄
                Instantiate(itemBoom, this.transform.position, itemBoom.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }

    private void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderBullet")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "PlayerBullet")
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();
            OnHit(bullet.damage);

            Destroy(collision.gameObject);
        }

    }
    
}
