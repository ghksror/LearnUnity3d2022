using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
public class DataManager
{

    private static DataManager instance;
    private Dictionary<int, StageData> dicStageDatas;
    private Dictionary<int, StageMissionData> dicStageMissionDatas;
    private Dictionary<int, ItemData> dicItemDatas;

    private DataManager()
    {

    }


    public static DataManager GetInstance()
    {
        if(DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
        }
        return DataManager.instance;
    }


    public void LoadStageData()
    {
        var json = Resources.Load<TextAsset>("Data/stage_data").text;
        this.dicStageDatas = JsonConvert.DeserializeObject<StageData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded stage_data : {0}", this.dicStageDatas.Count);
    }

    public void LoadItemData()
    {
        var json = Resources.Load<TextAsset>("Data/item_data").text;
        this.dicItemDatas = JsonConvert.DeserializeObject<ItemData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded item_data : {0}", this.dicItemDatas.Count);
    }

    public void StageMissionData()
    {
        var json = Resources.Load<TextAsset>("Data/stage_mission_data").text;
        this.dicStageMissionDatas = JsonConvert.DeserializeObject<StageMissionData[]>(json).ToDictionary(x => x.id);
        Debug.LogFormat("Loaded stage_mission_data : {0}", this.dicStageMissionDatas.Count);
    }

    public int GetStageDataCount()
    {
        return this.dicStageDatas.Count;
    }

}
