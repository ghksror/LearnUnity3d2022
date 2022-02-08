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
        Debug.LogFormat("are u newbie : {0}", newbie); //����� �ƴϳ� = true ���;���
        if (newbie)
        {
            //������ game_info.json ������ ���� �������ش�(���ʷ� �ѹ���)
            this.CreateAndSaveGameInfo();
        }
        else
        {
            //��������
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
        string path = Application.persistentDataPath + "/game_info.json"; // ���ø����̼� ��ġ������ game_info.json�� ������Ȳ���� ����� �ƴϴٸ� ã��
        //Debug.Log(path);
        return !File.Exists(path); //!�� �ٿ���� Ʈ��
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
