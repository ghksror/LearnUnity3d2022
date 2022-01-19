using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public Button[] arrBtns;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<arrBtns.Length; i++)
        {
            int index = i;
            Button btn = this.arrBtns[index];
            btn.onClick.AddListener(() =>
            {
                Debug.Log(index);
            });

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
