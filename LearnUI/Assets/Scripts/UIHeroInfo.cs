using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeroInfo : MonoBehaviour
{
    public Text userNameText;
    public Text levelText;
    public Text attackText;
    public Text defenseText;
    public Text healthText;
    public Text goldText;
    public Text gemText;

    
    public void Init(string userName, float level, float attack, float defense, float health, int gold, int gem)
    {
        this.userNameText.text = userName.ToString();
        this.levelText.text = level.ToString();
        this.attackText.text = attack.ToString();
        this.defenseText.text = defense.ToString();
        this.healthText.text = health.ToString();
        this.goldText.text = gold.ToString();
        this.gemText.text = gem.ToString();
    }

}
