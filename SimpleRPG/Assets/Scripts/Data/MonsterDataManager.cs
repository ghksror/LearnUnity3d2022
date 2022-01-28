using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

//싱글톤 클라스
public class MonsterDataManager
{
    //정적 멤버
    private static MonsterDataManager instance;
    Dictionary<int, MonsterData> dicMonsterDatas;
    //private 생성자
    private MonsterDataManager()
    {
        this.dicMonsterDatas = new Dictionary<int, MonsterData>();

    }

    //정적 메서드를 통해 인스턴스를 반환하는 메서드 정의
    public static MonsterDataManager GetInstance()
    {
        //인스턴스는 1개여야한다.
        if(MonsterDataManager.instance == null)
        {
            MonsterDataManager.instance = new MonsterDataManager();
        }
        return MonsterDataManager.instance;
    }


    public void LodeMonsterData()
    {

        string path = "Data/monster_data";
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;

        MonsterData[] arrMonsterDates = JsonConvert.DeserializeObject<MonsterData[]>(json);
        for (int a = 0; a < arrMonsterDates.Length; a++)
        {
            MonsterData monsterData = arrMonsterDates[a];
            Debug.LogFormat("{0},{1},{2},{3},{4},{5}", monsterData.id, monsterData.name, monsterData.hp, monsterData.damage, monsterData.attackSpeed, monsterData.prefabName);
            dicMonsterDatas.Add(monsterData.id, monsterData);
        }


    }


}
