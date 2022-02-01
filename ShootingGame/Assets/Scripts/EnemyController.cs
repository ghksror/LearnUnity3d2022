using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float hp;
    public Sprite[] sprites; //일반, 히트상태 두개기때문에 배열로사용

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed; //Vector2인 이유는 릿지드바디2D이기때문
    }

    private void OnHit(float damage)
    {
        hp -= damage;
        spriteRenderer.sprite = sprites[1]; //평소 스프라이트=0, 히트 스프라이트=1
        Invoke("ReturnSprite", 0.1f); //리턴스프라이트 메서드를 호출하고0.1초뒤에 호출해주세요라는의미 
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
