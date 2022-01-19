using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UILobby : MonoBehaviour
{
    public Button[] arrBtns;
    public Action<string> onSelectedPlayer;
    //private Dictionary<int ,playerData> (나중에 테이블만들어서 데이터 관리할때 이런형식으로진행할것)
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<arrBtns.Length; i++)
        {
            int index = i;
            Button btn = this.arrBtns[index];
            btn.onClick.AddListener(() =>
            {
                //Debug.Log(index); // <- 가 Dictionary 사전의 키와 같은 의미다.
                //이제 플레이어 인덱스 0 , 1 , 2번중에 선택을한것을
                //프리팹으로 만들어서 다음씬으로 가져가야됨 (프리팹이름 현재 Player_01 , _02 ,_03으로 만들어져있음)
                string prefabname = string.Format("Player_0{0}", index+1); //인덱스는 0부터고 이름은 1부터니까 +1해주었다.
                Debug.LogFormat("prefabName: {0}",prefabname);
                this.onSelectedPlayer(prefabname);

                //선택한 캐릭터를 이제 게임 씬으로 가져가야한다.(게임 메인 스크립트에서 실행하니거기로 가져가야함)
                //그런데 게임 씬에는 이미 플레이어가 만들어져있다. 그럼 안되니까
                //플레이어를 삭제해줘야하는데 플레이어 오브젝트는 현재 플레이어 컨트롤러 라는 스크립트 컴포넌트를 가지고있다.
                //여기는 UI를 관리하는 스크립트니 다른곳에서 넘겨주도록하자.
            });

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
