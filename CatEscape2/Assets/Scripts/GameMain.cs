using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static bool isGameOver = false;

    public PlayController player;
    public UIGame uiGame;
    public ArrowGenerator arrowGenerator;

    // Start is called before the first frame update
    void Start()
    {
        this.player.OnHit = (fillAmount) => 
        {
            this.uiGame.UpdateHpGauge(fillAmount);
        };

        this.player.OnDie = () => 
        {
            if (!GameMain.isGameOver)
            {
                GameMain.isGameOver = true;
                Debug.Log("player is dead");

                this.uiGame.GameOver();
            }
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
