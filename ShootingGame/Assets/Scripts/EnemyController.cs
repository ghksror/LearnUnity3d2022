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
    public Sprite[] sprites; //�Ϲ�, ��Ʈ���� �ΰ��⶧���� �迭�λ��

    public float maxShotDelay;  //���� ������
    public float curShotDelay;  //�ѹ� ������ �����Ǳ������ ������

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
        rigid.velocity = Vector2.down * speed; //Vector2�� ������ ������ٵ�2D�̱⶧��*/
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


        curShotDelay = 0; //�Ѿ��� �� �i���� �ٽ� �������ؾ��ϹǷ� 0�����ʱ�ȭ
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
        spriteRenderer.sprite = sprites[1]; //��� ��������Ʈ=0, ��Ʈ ��������Ʈ=1
        Invoke("ReturnSprite", 0.1f); //���Ͻ�������Ʈ �޼��带 ȣ���ϰ�0.1�ʵڿ� ȣ�����ּ������ǹ� 
        if(hp <= 0)
        {
            PlayerController playerLogic = player.GetComponent<PlayerController>();
            playerLogic.score += enemyScore;

            //Random Ratio Item Drop ���Ⱑ �������� ����Ȯ���� �����۵��
            int ran = Random.Range(0, 10);
            if(ran < 5)
            {
                //50%�̵��
                
            }
            else if (ran < 8)
            {
                //30%��
                Instantiate(itemCoin, this.transform.position, itemCoin.transform.rotation);
            }
            else if (ran < 9)
            {
                //10%�Ŀ�
                Instantiate(itemPower, this.transform.position, itemPower.transform.rotation);
            }
            else if (ran < 10)
            {
                //10%��ź
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
