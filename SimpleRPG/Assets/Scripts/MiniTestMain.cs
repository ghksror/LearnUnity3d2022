using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MiniTestMain : MonoBehaviour
{
    public GameObject hpgolemPrefab;
    public GameObject pbrgolemPrefab;
    public GameObject polyartgolemPrefab;
    public Button btn;
    Coroutine routine;

    private List<GameObject> golems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //데이터 로드
        MonsterDataManager.GetInstance().LodeMonsterData();

        this.btn.onClick.AddListener(() =>
        {
            this.CreateHpGolems();
            this.CreatePBRGolems();
            this.CreatePolyartGolems();
        });

    }

    private void CreateHpGolems()
    {
        for (int i = 0; i < 3; i++)
        {
            var golemGo = Instantiate(this.hpgolemPrefab);
            golemGo.name = string.Format("HpGolem {0}", i);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            golemGo.transform.position = initPos;

            this.golems.Add(golemGo);
        }
    }

    private void CreatePBRGolems()
    {
        for (int i = 0; i < 3; i++)
        {
            var golemGo = Instantiate(this.hpgolemPrefab);
            golemGo.name = string.Format("pbrGolem {0}", i);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            golemGo.transform.position = initPos;

            this.golems.Add(golemGo);
        }
    }

    private void CreatePolyartGolems()
    {
        for (int i = 0; i < 3; i++)
        {
            var golemGo = Instantiate(this.hpgolemPrefab);
            golemGo.name = string.Format("polyartGolem {0}", i);
            var randX = Random.Range(-5, 5);
            var randZ = Random.Range(-5, 5);
            var initPos = new Vector3(randX, 0, randZ);
            golemGo.transform.position = initPos;

            this.golems.Add(golemGo);
        }
    }

}
