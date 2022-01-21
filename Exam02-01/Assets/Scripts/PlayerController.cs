using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject bulletPrefab;
    public Transform firepoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var dir = Vector2.left;
            this.transform.Translate(-1*this.speed *Time.deltaTime,0,0);
            
            if ( this.transform.position.x <= -2.3f)
            {
                var pos = this.transform.position;
                pos.x = -2.3f;
                this.transform.position = pos;
            }

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            var dir = Vector2.right;
            this.transform.Translate(1 * this.speed * Time.deltaTime,0,0);
            if (this.transform.position.x >= 2.3f)
            {
                var pos = this.transform.position;
                pos.x = 2.3f;
                this.transform.position = pos;
            }
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            var dir = Vector2.up;
            this.transform.Translate(0, dir.y * this.speed * Time.deltaTime,0);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            var dir = Vector2.down;
            this.transform.Translate(0, dir.y * this.speed * Time.deltaTime,0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //√—æÀ«¡∏Æ∆’¿ŒΩ∫≈œΩ∫»≠
            var bulletGo = Instantiate<GameObject>(this.bulletPrefab);
            bulletGo.transform.position = this.firepoint.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("RestartScene");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("RestartScene");
        }

    }


}
