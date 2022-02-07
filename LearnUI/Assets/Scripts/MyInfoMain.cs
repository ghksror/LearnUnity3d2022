using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //File을 읽을때 사용
using Newtonsoft.Json;
using UnityEngine.U2D;
using System.Linq;
using UnityEngine.UI;
public class MyInfoMain : MonoBehaviour
{
    public GameObject uiListItemPrefab;
    private Dictionary<int, ItemData> dic;
    public SpriteAtlas atlas;
    public Transform horizontalGrid;
    public UIHeroInfo uiHeroInfo;
    public UIItem[] uiListItems;
    private System.Action<ItemInfo[]> loadedItemInfosAction;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        this.btn.onClick.AddListener(() =>
        {
            this.UpdateInventory();

            // uiListItems에 있는 요소 countText값을 가져오기 보다는
            // 정보객체로부터 가져오는것이 안전하다
        });
        this.loadedItemInfosAction = (itemInfos) =>
        {
            int totalCount = 0;
            foreach(var info in itemInfos)
            {
                totalCount += info.count;
            }

            Debug.LogFormat("<color=yellow>totalCount: {0}</color>", totalCount);
        };

        this.LoadItemData();
        this.InitInventory();

        //********************************************
        //C:/Users/유혁진/AppData/LocalLow/DefaultCompany/LearnUI
        Debug.Log(Application.persistentDataPath); //1.경로를 확인한다.
        //2.확인한 경로에 json파일을 넣는다.

        var json = File.ReadAllText(Application.persistentDataPath + "/hero_info.json"); //3.넣은json파일정보를 로드한다. using System.IO;필요
        //Debug.Log(json);

        //HeroInfo.cs에 매핑하고난뒤 역직렬화한다. string -> object(HeroInfo객체) 읽은 데이터를 메모리에 올리기위함
        HeroInfo heroInfo = JsonConvert.DeserializeObject<HeroInfo>(json);
        //Debug.Log(heroInfo.attack);

        //heroinfo에 저장된 정보를 불러와서 UI에 표시하기
        this.uiHeroInfo.Init(heroInfo.userName, heroInfo.level, heroInfo.attack, heroInfo.defense, heroInfo.health, heroInfo.gold, heroInfo.gem);

    }
    private void LoadItemData()
    {
        var json = Resources.Load<TextAsset>("Item_data").text;
        this.dic = JsonConvert.DeserializeObject<ItemData[]>(json).ToDictionary(x => x.id);
    }

    private void InitInventory()
    {
        int i = 0;
        foreach (var data in this.dic.Values)
        {
            var sp = this.atlas.GetSprite(data.spriteName);
            var uiListItem = this.uiListItems[i++];
            uiListItem.Init(data.id, sp, 0);
        }
    }

    private void UpdateInventory()
    {
        this.LoadItemInfos();

    }

    private void LoadItemInfos()
    {
        var path = string.Format("{0}/items_info.json", Application.persistentDataPath);
        //Debug.Log(path);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            Debug.Log(json);

            var list = this.uiListItems.ToList();

            ItemInfo[] itemInfos = JsonConvert.DeserializeObject<ItemInfo[]>(json);
            for(int i= 0; i<itemInfos.Length; i++)
            {
                ItemInfo info = itemInfos[i];
                var uiListItem = list.Find(x=>x.id == info.id);
                if(uiListItem != null)
                {
                    uiListItem.UpdateCount(info.count);
                }
            }

            this.loadedItemInfosAction(itemInfos);

        }
        else
        {
            Debug.Log("파일을 찾을수 없습니다.");
        }
    }
}
