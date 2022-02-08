using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GameEditor : MonoBehaviour
{
    [MenuItem("wardhouse/Delete GameInfo")]
    static void DeleteGameInfo()
    {
        var path = Application.persistentDataPath + "/game_info.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            print("game_info.json을 삭제 했습니다.");
            ShowExplorer(Application.persistentDataPath);
        }
        else
        {
            Debug.Log("파일을 찾을수 없습니다.");
        }
    }

    public static void ShowExplorer(string itemPath)
    {
        itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes

        Debug.Log(itemPath);
        System.Diagnostics.Process.Start("explorer.exe", "/select," + itemPath);
    }


}
