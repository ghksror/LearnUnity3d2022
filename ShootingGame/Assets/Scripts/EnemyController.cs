using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float hp;
    public Sprite[] sprites; //�Ϲ�, ��Ʈ���� �ΰ��⶧���� �迭�λ��

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed; //Vector2�� ������ ������ٵ�2D�̱⶧��
    }

    private void OnHit(float damage)
    {
        hp -= damage;
        spriteRenderer.sprite = sprites[1]; //��� ��������Ʈ=0, ��Ʈ ��������Ʈ=1
        Invoke("ReturnSprite", 0.1f); //���Ͻ�������Ʈ �޼��带 ȣ���ϰ�0.1�ʵڿ� ȣ�����ּ������ǹ� 
        if(hp <= 0)
        {
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
