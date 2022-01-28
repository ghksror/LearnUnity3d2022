using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

//�̱��� Ŭ����
public class DataManager
{
    //���� ���
    private static DataManager instance;
    Dictionary<int, WeaponData> dicWeaponDatas;
    //private ������ public �ƴ�
    private DataManager()
    {
        this.dicWeaponDatas = new Dictionary<int, WeaponData>();
    }

    //���� �޼��带 ���ؼ� �ν��Ͻ��� ��ȯ�ϴ� �޼��� ����
    public static DataManager GetInstance()
    {
        //�ν��Ͻ��� 1������ �Ѵ�.
        if(DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }

        return DataManager.instance;
    }

    //�ν��Ͻ� �޼��� �����͸� �ε���

    public void LoadWeaponData()
    {

        //json���� ���ҽ� �ؽ�Ʈ �ε�
        string path = "Data/weapon_data";
        //Resources.Load(path);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;

        //������ȭ
        WeaponData[] arrWeaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json);
        for (int i = 0; i < arrWeaponDatas.Length; i++)
        {
            WeaponData weaponData = arrWeaponDatas[i];
            Debug.LogFormat("{0} , {1} , {2} , {3} , {4}", weaponData.id, weaponData.name, weaponData.damage, weaponData.attackSpeed, weaponData.prefabName);
            dicWeaponDatas.Add(weaponData.id, weaponData);
        }
    }

    public WeaponData GetWeaponData(int id)
    {
        return this.dicWeaponDatas[id];
    }

}
