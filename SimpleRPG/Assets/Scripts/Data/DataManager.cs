using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

//싱글톤 클래스
public class DataManager
{
    //정적 멤버
    private static DataManager instance;
    Dictionary<int, WeaponData> dicWeaponDatas;
    //private 생성자 public 아님
    private DataManager()
    {
        this.dicWeaponDatas = new Dictionary<int, WeaponData>();
    }

    //정석 메서드를 통해서 인스턴스를 반환하는 메서드 정의
    public static DataManager GetInstance()
    {
        //인스턴스는 1개여야 한다.
        if(DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }

        return DataManager.instance;
    }

    //인스턴스 메서드 데이터를 로드함

    public void LoadWeaponData()
    {

        //json파일 리소스 텍스트 로드
        string path = "Data/weapon_data";
        //Resources.Load(path);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        string json = textAsset.text;

        //역직렬화
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
