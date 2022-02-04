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
        //item_data.json 데이터를 로드한다.
        var textAsset = Resources.Load<TextAsset>("item_data");
        var itemDataJson = textAsset.text;
        //역직렬화
        ItemData[] itemDatas = JsonConvert.DeserializeObject<ItemData[]>(itemDataJson);
        Dictionary<int,ItemData> dicItemDatas = new Dictionary<int, ItemData>();
        foreach (var itemData in itemDatas)
        {
            dicItemDatas.Add(itemData.id, itemData);
        }
        Debug.Log(dicItemDatas.Count);

        //********************************************

        //C:/Users/유혁진/AppData/LocalLow/DefaultCompany/LearnUI
        Debug.Log(Application.persistentDataPath); //1.경로를 확인한다.
        //2.확인한 경로에 json파일을 넣는다.

        var json = File.ReadAllText(Application.persistentDataPath + "/hero_info.json"); //3.넣은json파일정보를 로드한다.
        Debug.Log(json);

        //HeroInfo.cs에 매핑하고난뒤 역직렬화한다. string -> object(HeroInfo객체) 읽은 데이터를 메모리에 올리기위함
        HeroInfo heroInfo = JsonConvert.DeserializeObject<HeroInfo>(json);
        Debug.Log(heroInfo.attack);

        //Heroinfo에 저장된 정보를 불러와서 UI에 표시하기
        this.uiHeroInfo.Init(heroInfo.userName, heroInfo.level, heroInfo.attack, heroInfo.defense, heroInfo.health, heroInfo.gold, heroInfo.gem);

        //********************************************

        //아이템을 획득했다...
        /*var itemInfo0 = this.GetItem(100,2);
        var itemInfo1 = this.GetItem(101,1);
        var itemInfo2 = this.GetItem(102,11);
        var itemInfo3 = this.GetItem(103,0);
        var itemInfo4 = this.GetItem(104,0);
        var itemInfo5 = this.GetItem(105,3);

        //배열에 넣는다
        List<ItemInfo> list = new List<ItemInfo>();
        list.Add(itemInfo0);
        list.Add(itemInfo1);
        list.Add(itemInfo2);
        list.Add(itemInfo3);
        list.Add(itemInfo4);
        list.Add(itemInfo5);

        //직렬화(object -> json)
        var itemsJson = JsonConvert.SerializeObject(list);

        //출력
        Debug.Log(itemsJson);
        //[{"id":100,"amount":2},{"id":101,"amount":1},{"id":102,"amount":11},{"id":103,"amount":0},{"id":104,"amount":0},{"id":105,"amount":3}]


        //파일로 저장
        var path = Application.persistentDataPath + "/items_info.json";
        Debug.Log(path);
        File.WriteAllText(path, itemsJson);*/

        //********************************************
        //MyInfoMain에 저장된걸 확인했으니 사용하려면 MyInfoMain에서 다시 불러와야한다.

        var path = Application.persistentDataPath + "/items_info.json";
        
        var itemsJson = File.ReadAllText(path);//[{"id":100,"amount":2},{"id":101,"amount":1},{"id":102,"amount":11},{"id":103,"amount":0},{"id":104,"amount":0},{"id":105,"amount":3}]
        //역직렬화 (string -> object)
        var itemInfos = JsonConvert.DeserializeObject<ItemInfo[]>(itemsJson);
        //UIInventory에게 배열을 전달
        this.uiInventory.Init(itemInfos, dicItemDatas);

    }

    public ItemInfo GetItem(int id,int amount)
    {
        return new ItemInfo(id,amount);
    }
    
}
