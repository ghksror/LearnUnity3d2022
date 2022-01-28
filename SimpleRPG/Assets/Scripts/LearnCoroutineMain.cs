using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnCoroutineMain : MonoBehaviour
{
    public HeroController hero;
    private MonsterController targetSlime;
    public Button btn;
    public GameObject slimePrefabs;
    public GameObject fxprefab;
    private List<GameObject> slimes = new List<GameObject>();

    //public Transform heroTrans;
    //public Transform slimeTrans;
    // Start is called before the first frame update
    void Start()
    {
        this.CreateSlimes();

        this.hero.OnAttackComplete = (completeType) =>
        {
            this.OrderHeroAttack();
        };
        this.hero.OnAttackImpact = (impectType) =>
        {
            switch (impectType)
            {

                case HeroController.eAttackType.Attack01:
                    //Debug.Log("공격 1");
                    CreateFx();
                    break;
                    
                case HeroController.eAttackType.Attack02:
                    //Debug.Log("공격 2");
                    CreateFx();
                    break;
                    
            }
        };

        this.btn.onClick.AddListener(() =>
        {
            //this.heroTrans.LookAt(slimeTrans.position);
            //this.hero.Attack(this.slime);
            this.OrderHeroAttack();

        });
    }

    private void OrderHeroAttack()
    {
        var targetGo = this.SearchTarget();
        if(targetGo == null)
        {
            this.hero.Idle();
        }
        else
        {
            this.targetSlime = targetGo.GetComponent<MonsterController>();
            this.hero.Attack(this.targetSlime);
        }
    }

    private GameObject SearchTarget()
    {
        float max = Mathf.Infinity;
        GameObject targetGo = null;

        foreach (var go in slimes)
        {
            var dis = Vector3.Distance(go.transform.position, this.transform.position);
            if (dis < max)
            {
                max = dis;
                targetGo = go;
            }
        }

        //Debug.LogFormat("타겟을 찾았다 : {0}", targetGo.name);
        return targetGo;
    }

    private void CreateFx()
    {
        var fxGo = Instantiate(this.fxprefab);
        fxGo.transform.position = this.hero.fxPivot.position;
    }

    private void CreateSlimes()
    {
        for(int i = 0; i <3; i++)
        {
            var slimeGo = Instantiate(this.slimePrefabs);
            slimeGo.name = string.Format("Slime {0}", i);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            slimeGo.transform.position = initPos;

            slimeGo.GetComponent<MonsterController>().OnDieAction = () =>
            {
                this.slimes.Remove(slimeGo);
            };

            this.slimes.Add(slimeGo);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
