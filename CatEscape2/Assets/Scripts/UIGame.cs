using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGame : MonoBehaviour
{
    public Image hpGauge;
    public GameObject gameOverGo;

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverGo.SetActive(false);
    }

    public void UpdateHpGauge(float fillAmount)
    {
        hpGauge.fillAmount = fillAmount;
    }

    public void GameOver()
    {
        this.gameOverGo.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
