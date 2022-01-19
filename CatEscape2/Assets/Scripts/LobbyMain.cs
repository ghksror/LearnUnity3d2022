using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMain : MonoBehaviour
{
    public UILobby uiLobby;
    // Start is called before the first frame update
    void Start()
    {
        this.uiLobby.onSelectedPlayer = (prefabName) =>
        {
            //캐릭터를 골랐을때 로비 > 게임 씬전환
            //SceneManager.LoadScene("GameScene"); // 로드씬을 할경우 동기방식으로 진행된다. 이럴경우 로드이후 삭제되기때문에
                                                 // 게임메인에서 이곳의 정보를 가져갈수없게된다. 그래서 비동기방식으로 진행해야한다.
                                                 // (아예 못하는건아님 직접찾아서 할수는있다 .Find를 통하여)
                                                 
            AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");//비동기 방식 메서드를 보면 Async Operation이라는걸
                                                                                //반환하는걸 확인할수있다.
            operation.completed += (oper) => 
            {
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>(); //씬이 로드는 됐지만 아직 활성화되기전상태이다.(그게 LoadSceneAsync)
                gameMain.Init(prefabName);                                   // 로드가 됐다 = 메모리에 올라갔다.
                                                                   // 메모리에 올라갔다 = 씬 안에있는 <GameMain>이라는 컴포넌트에 접근이가능하다.
            };

        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
