using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int life;
    public int score;
    public float speed;
    public float bulletSpeed = 10;
    public float power;
    public float maxShotDelay;  //실제 딜레이
    public float curShotDelay;  //한발 쏜이후 충전되기까지의 딜레이

    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public GameObject bulletAPrefab;
    public GameObject bulletBPrefab;

    public GameManager manager;
    public bool isHit;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 PlayerPos = this.transform.position;
        Vector3 NextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;//transform 이동에는 Time.deltaTime 꼭 사용

        transform.position = PlayerPos + NextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    private void Fire()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }
        if (curShotDelay < maxShotDelay)
        {
            return;
        }
        switch (power)
        {
            case 1:
                GameObject bulletGo = Instantiate(bulletAPrefab, this.transform.position, this.transform.rotation);
                Rigidbody2D rigid = bulletGo.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletRGo = Instantiate(bulletAPrefab, this.transform.position+Vector3.right*0.1f, this.transform.rotation);
                Rigidbody2D rigidR = bulletRGo.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                GameObject bulletLGo = Instantiate(bulletAPrefab, this.transform.position+Vector3.left*0.1f, this.transform.rotation);
                Rigidbody2D rigidL = bulletLGo.GetComponent<Rigidbody2D>();
                rigidL.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletRRGo = Instantiate(bulletAPrefab, this.transform.position + Vector3.right * 0.3f, this.transform.rotation);
                Rigidbody2D rigidRR = bulletRRGo.GetComponent<Rigidbody2D>();
                rigidRR.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                GameObject bulletLLGo = Instantiate(bulletAPrefab, this.transform.position + Vector3.left * 0.3f, this.transform.rotation);
                Rigidbody2D rigidLL = bulletLLGo.GetComponent<Rigidbody2D>();
                rigidLL.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                GameObject bulletCCGo = Instantiate(bulletBPrefab, this.transform.position, this.transform.rotation);
                Rigidbody2D rigidCC = bulletCCGo.GetComponent<Rigidbody2D>();
                rigidCC.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
                break;
        }

        //Power One(한발씩발사하기때문)
        curShotDelay = 0; //총알을 다 쐇으면 다시 장전을해야하므로 0으로초기화
    }

    private void Reload()
    {
        curShotDelay += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (isHit)
            {
                return;
            }
            isHit = true;
            life--;
            manager.UpdateLifeIcon(life);

            if(life == 0)
            {
                manager.GameOver();
            }
            else
            {
                manager.RespawnPlayer();
            }

            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

}
