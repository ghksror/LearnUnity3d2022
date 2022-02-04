using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class MyInfoMain : MonoBehaviour
{

    public UIHeroInfo uiHeroInfo;
    public UIInventory uiInventory;

    // Start is called before the first frame update
    void Start()
    {
        //item_data.json �����͸� �ε��Ѵ�.
        var textAsset = Resources.Load<TextAsset>("item_data");
        var itemDataJson = textAsset.text;
        //������ȭ
        ItemData[] itemDatas = JsonConvert.DeserializeObject<ItemData[]>(itemDataJson);
        Dictionary<int,ItemData> dicItemDatas = new Dictionary<int, ItemData>();
        foreach (var itemData in itemDatas)
        {
            dicItemDatas.Add(itemData.id, itemData);
        }
        Debug.Log(dicItemDatas.Count);

        //********************************************

        //C:/Users/������/AppData/LocalLow/DefaultCompany/LearnUI
        Debug.Log(Application.persistentDataPath); //1.��θ� Ȯ���Ѵ�.
        //2.Ȯ���� ��ο� json������ �ִ´�.

        var json = File.ReadAllText(Application.persistentDataPath + "/hero_info.json"); //3.����json���������� �ε��Ѵ�.
        Debug.Log(json);

        //HeroInfo.cs�� �����ϰ��� ������ȭ�Ѵ�. string -> object(HeroInfo��ü) ���� �����͸� �޸𸮿� �ø�������
        HeroInfo heroInfo = JsonConvert.DeserializeObject<HeroInfo>(json);
        Debug.Log(heroInfo.attack);

        //Heroinfo�� ����� ������ �ҷ��ͼ� UI�� ǥ���ϱ�
        this.uiHeroInfo.Init(heroInfo.userName, heroInfo.level, heroInfo.attack, heroInfo.defense, heroInfo.health, heroInfo.gold, heroInfo.gem);

        //********************************************

        //�������� ȹ���ߴ�...
        /*var itemInfo0 = this.GetItem(100,2);
        var itemInfo1 = this.GetItem(101,1);
        var itemInfo2 = this.GetItem(102,11);
        var itemInfo3 = this.GetItem(103,0);
        var itemInfo4 = this.GetItem(104,0);
        var itemInfo5 = this.GetItem(105,3);

        //�迭�� �ִ´�
        List<ItemInfo> list = new List<ItemInfo>();
        list.Add(itemInfo0);
        list.Add(itemInfo1);
        list.Add(itemInfo2);
        list.Add(itemInfo3);
        list.Add(itemInfo4);
        list.Add(itemInfo5);

        //����ȭ(object -> json)
        var itemsJson = JsonConvert.SerializeObject(list);

        //���
        Debug.Log(itemsJson);
        //[{"id":100,"amount":2},{"id":101,"amount":1},{"id":102,"amount":11},{"id":103,"amount":0},{"id":104,"amount":0},{"id":105,"amount":3}]


        //���Ϸ� ����
        var path = Application.persistentDataPath + "/items_info.json";
        Debug.Log(path);
        File.WriteAllText(path, itemsJson);*/

        //********************************************
        //MyInfoMain�� ����Ȱ� Ȯ�������� ����Ϸ��� MyInfoMain���� �ٽ� �ҷ��;��Ѵ�.

        var path = Application.persistentDataPath + "/items_info.json";
        
        var itemsJson = File.ReadAllText(path);//[{"id":100,"amount":2},{"id":101,"amount":1},{"id":102,"amount":11},{"id":103,"amount":0},{"id":104,"amount":0},{"id":105,"amount":3}]
        //������ȭ (string -> object)
        var itemInfos = JsonConvert.DeserializeObject<ItemInfo[]>(itemsJson);
        //UIInventory���� �迭�� ����
        this.uiInventory.Init(itemInfos, dicItemDatas);

    }

    public ItemInfo GetItem(int id,int amount)
    {
        return new ItemInfo(id,amount);
    }
    
}
