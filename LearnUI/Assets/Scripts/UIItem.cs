using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class UIItem : MonoBehaviour
{
    //423B31 = plus
    //FFFFFF = item icon

    public Image icon;

    public Text countText;
    public GameObject countGo;  // 0개 일경우 B22827, 1개 이상 : 877862
    public int id;
    public void Init(int id, Sprite sp, int count)
    {
        this.id = id;
        this.icon.sprite = sp;
        this.countText.text = count.ToString();

        Color color;
        ColorUtility.TryParseHtmlString("#FFFFFF", out color);
        this.icon.color = color;
        this.icon.SetNativeSize();

        string hexString = (count == 0) ? "#B22827" : "#877862";
        Color colorText;
        ColorUtility.TryParseHtmlString(hexString, out colorText);
        this.countText.color = colorText;

        this.countGo.SetActive(true);
    }

    public void UpdateCount(int count)
    {
        string hexString = (count == 0) ? "#B22827" : "#877862";
        Color colorText;
        ColorUtility.TryParseHtmlString(hexString, out colorText);
        this.countText.color = colorText;

        this.countText.text = count.ToString();
    }


}
