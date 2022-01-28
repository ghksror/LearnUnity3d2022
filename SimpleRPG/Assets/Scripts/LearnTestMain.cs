using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnTestMain : MonoBehaviour
{
    public SubPlayerController player;
    public SubMonsterController monster;
    public Button runbtn;
    public Button atcbtn;

    // Start is called before the first frame update
    void Start()
    {

        this.player.OnAttackImpact = (impactType) =>
        {
            monster.Hit(player.damage);
        };

        this.runbtn.onClick.AddListener(() =>
        {
            player.PlayerMove();

        });

        this.atcbtn.onClick.AddListener(() =>
        {
            player.PlayerAttack();
            
        });
    }

}
