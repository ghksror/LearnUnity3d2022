using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

public class MiniTestMain : MonoBehaviour
{
    public List<UIItemSlot> slots;
    private Dictionary<int, TestItemData> dic;
    public SpriteAtlas atlas;
    private List<MyItemInfo> myItemInfos;
    public Button btn;
    private int selectedSlotId = -1;

    // Start is called before the first frame update
    void Start()
    {
        this.LoadData();

        this.InitUI();

        this.btn.onClick.AddListener(() =>
        {
            //버튼 클릭시 my_item_infos.json 로드 & 인벤토리 업데이트
            this.LoadMyItemsInfo();
            this.UpdateUI();
        });
    }
    private void InitUI()
    {
        foreach(var slot in this.slots)
        {
            slot.selectedAction = (id) =>
            {

                Debug.LogFormat("selected id:{0}, id: {1}",this.selectedSlotId, id);

                if(id == 0)
                {
                    return; //아이템이 없다면 리턴
                }

                if(this.selectedSlotId != id)
                {
                    this.InVisibleSelectedMark();
                    this.selectedSlotId = id;
                    this.VisibleSelectedMark();
                }
                else
                {
                    this.InVisibleSelectedMark();
                    this.selectedSlotId = -1;
                }
            };
        }
    }

    private void InVisibleSelectedMark()
    {
        foreach (var slot in this.slots)
        {
            slot.selectedGo.SetActive(false);
        }
    }

    private void VisibleSelectedMark()
    {
        foreach (var slot in this.slots)
        {
            if(slot.id == this.selectedSlotId)
            {
                slot.selectedGo.SetActive(true);
            }
        }
    }

    private void LoadMyItemsInfo()
    {
        var path = Application.persistentDataPath + "/my_item_infos.json";
        var json = File.ReadAllText(path);
        if (this.myItemInfos!=null)
        {
            this.myItemInfos.Clear();
        }
        this.myItemInfos = JsonConvert.DeserializeObject<MyItemInfo[]>(json).ToList();
    }

    private void UpdateUI()
    {

        for(int i = 0; i<this.slots.Count; i++)
        {
            Debug.LogFormat("{0},{1}", i, this.myItemInfos.Count - 1);

            if (i < this.myItemInfos.Count)
            {
                var info = this.myItemInfos[i];
                var data = this.dic[info.id];
                var sp = this.atlas.GetSprite(data.spriteName);
                var slot = this.slots[i];
                slot.Init(info.id, sp, info.count);
            }
        }
    }

    private void LoadData()
    {
        var path = "MiniTest/Data/item_data";
        var textAsset = Resources.Load<TextAsset>(path);
        var json = textAsset.text;
        Debug.Log(json);

        this.dic = JsonConvert.DeserializeObject<TestItemData[]>(json).ToDictionary(x => x.id);
    }
}
