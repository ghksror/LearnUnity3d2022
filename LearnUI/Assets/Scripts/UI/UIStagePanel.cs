using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStagePanel : MonoBehaviour
{

    public Text numText;

    public void Init(int num)
    {
        this.numText.text = num.ToString();
    }

}
