using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

//�̱��� Ŭ��
public class MonsterDataManager
{
    //���� ���
    private static MonsterDataManager instance;
    Dictionary<int, MonsterData> dicMonsterDatas;
    //private ������
    private MonsterDataManager()
    {
        this.dicMonsterDatas = new Dictionary<int, MonsterData>();

    }

    //���� �޼��带 ���� �ν��Ͻ��� ��ȯ�ϴ� �޼��� ����
    public static MonsterDataManager GetInstance()
    {
        //�ν��Ͻ��� 1�������Ѵ�.
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
