using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public float speed = 2.0f;
    private float delta;
    private float span = 1.0f;
    public GameObject enemyABulletPrefab;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            //총알프리팹을 인스턴스화
            var bulletGo = Instantiate<GameObject>(this.enemyABulletPrefab);
            bulletGo.transform.position = this.firepoint.position;

        }

        var dir = Vector2.down;
        this.transform.Translate(dir * this.speed * Time.deltaTime);

        if (this.transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(this.gameObject);
        }


    }


}
