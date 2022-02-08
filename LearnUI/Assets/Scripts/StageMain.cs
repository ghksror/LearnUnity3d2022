using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class StageMain : MonoBehaviour
{
    public Transform grid;
    public GameObject uiStagePanelPrefab;
    
    void Start()
    {

        DataManager.GetInstance().LoadItemData();
        DataManager.GetInstance().LoadStageData();
        DataManager.GetInstance().StageMissionData();
        Debug.Log("<color=yellow>data load complete!</color>");


        bool newbie = this.IsNewbie();
        Debug.LogFormat("are u newbie : {0}", newbie); //뉴비냐 아니냐 = true 나와야함
        if (newbie)
        {
            //뉴비라면 game_info.json 파일을 만들어서 저장해준다(최초로 한번만)
            this.CreateAndSaveGameInfo();
        }
        else
        {
            //기존유저
            this.LoadGameInfo();
        }

        Debug.Log("<color=cyan>ready to play!!!</color>");

        this.InitStagePanel();
    }

    private void InitStagePanel()
    {
        var cnt = DataManager.GetInstance().GetStageDataCount();
        for(int i = 0; i<cnt; i++)
        {
            var go = Instantiate(this.uiStagePanelPrefab, this.grid);
            var panel = go.GetComponent<UIStagePanel>();
            var num = i + 1;
            panel.Init(num);
        }
    }

    private void LoadGameInfo()
    {
        string path = Application.persistentDataPath + "/game_info.json";
        var json = File.ReadAllText(path);
        InfoManager.GetInstance().gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
        Debug.LogFormat("game_info loaded : {0}", InfoManager.GetInstance().gameInfo);

    }



    private bool IsNewbie()
    {
        string path = Application.persistentDataPath + "/game_info.json"; // 어플리케이션 위치정보에 game_info.json의 보유현황으로 뉴비다 아니다를 찾기
        //Debug.Log(path);
        return !File.Exists(path); //!을 붙여줘야 트루
    }

    private void CreateAndSaveGameInfo()
    {
        var gameInfo = new GameInfo();
        var json = JsonConvert.SerializeObject(gameInfo);
        //Debug.Log(json);
        string path = Application.persistentDataPath + "/game_info.json";
        //Debug.Log(path);
        File.WriteAllText(path, json);
        //Debug.Log("saved game_info.json");
        ShowExplorer(Application.persistentDataPath);
    }
    public void ShowExplorer(string itemPath)
    {
        itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
    }

}
