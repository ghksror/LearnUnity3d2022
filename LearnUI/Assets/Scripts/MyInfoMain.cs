using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //File�� ������ ���
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

            // uiListItems�� �ִ� ��� countText���� �������� ���ٴ�
            // ������ü�κ��� �������°��� �����ϴ�
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
        //C:/Users/������/AppData/LocalLow/DefaultCompany/LearnUI
        Debug.Log(Application.persistentDataPath); //1.��θ� Ȯ���Ѵ�.
        //2.Ȯ���� ��ο� json������ �ִ´�.

        var json = File.ReadAllText(Application.persistentDataPath + "/hero_info.json"); //3.����json���������� �ε��Ѵ�. using System.IO;�ʿ�
        //Debug.Log(json);

        //HeroInfo.cs�� �����ϰ��� ������ȭ�Ѵ�. string -> object(HeroInfo��ü) ���� �����͸� �޸𸮿� �ø�������
        HeroInfo heroInfo = JsonConvert.DeserializeObject<HeroInfo>(json);
        //Debug.Log(heroInfo.attack);

        //heroinfo�� ����� ������ �ҷ��ͼ� UI�� ǥ���ϱ�
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
            Debug.Log("������ ã���� �����ϴ�.");
        }
    }
}
