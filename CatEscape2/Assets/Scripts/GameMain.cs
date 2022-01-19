using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public static bool isGameOver = false;

    public PlayController player;
    public UIGame uiGame;
    public UIGameOver uiGameOver;
    public ArrowGenerator arrowGenerator;


    // Start is called before the first frame update
    void Start()
    {
        this.uiGameOver.btnRestart.onClick.AddListener(() =>
        {
            //��ư�� ������ ���� ���� �ε�
            SceneManager.LoadScene("GameScene");
            GameMain.isGameOver = false;
        });

        this.player.OnHit = (fillAmount) => 
        {
            this.uiGame.UpdateHpGauge(fillAmount);
        };

        this.player.OnDie = () => 
        {
            if (!GameMain.isGameOver)
            {
                GameMain.isGameOver = true;
                Debug.Log("�׾����ϴ�.");
                this.uiGame.GameOver();
            }
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
