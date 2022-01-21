using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyABullet : MonoBehaviour
{
    public float speed = 3.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector2.down;
        this.transform.Translate(dir * this.speed * Time.deltaTime);
        if (this.transform.position.y <= -5.5f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
