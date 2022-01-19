using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public static bool isGameOver = false;

    public PlayController player;
    public UIGame uiGame;
    public UIGameOver uiGameOver;
    public ArrowGenerator arrowGenerator;

    public Transform leftBoundary;
    public Transform rightBoundary;

    public string[] prefabNames = { "player_01", "player_02", "player_03" };
    public Dictionary<string, GameObject> dicPrefabs = new Dictionary<string, GameObject>();
    
    //public GameObject[] playerPrefabs; //직접 프리팹을 어싸인 하기 위함...
    //하지만 직접 로드하는 더 쉬운방법이있엇다. Assets/Resources폴더 생성 (예약폴더 이름정해져있음)
    //Resources이름을 가진 폴더안의 에셋은 Resources.Load 함수를 통해 접근 할수가있다.
    //프리팹을 폴더 안에넣고 찾아주기만하면 직접 어싸인할필요가 없다는뜻. (동적으로 로드할수있다.)

    // Start is called before the first frame update
    void Start() //아래 Init이 먼저 실행되므로 그냥 다 옮겨주었다.
    {

    }

    private void Awake()
    {
        foreach(string prefabName in this.prefabNames)
        {
            GameObject prefab = Resources.Load<GameObject>(prefabName);
            dicPrefabs.Add(prefabName, prefab);
        }
        
    }

    //Init 이 위쪽 void Start보다 먼저 호출되기때문에 start에 쓸필요가없다.
    public void Init(string prefabName)
    {
        var targetPrefab = this.dicPrefabs[prefabName];

        //새로운 플레이어를 만들어내야한다 <= 프리팹을 인스턴스화해야한다.
        //하지만 현재 게임메인에서는 프리팹을 가지고있지않다. 로비에서 가지고있지 그래서 그걸 넣어줘야한다.

        //프리팹을 인스턴스화
        
        GameObject playerGo = Instantiate(targetPrefab);  //플레이어를 불러올순있지만 불러온 플레이어는 컨트롤러와 아직 부착되어있지않다.


        //playerGo.transform.position = new Vector3(0, -3.7f, 0); //캐릭터 생성 포지션 설정

        this.player = playerGo.AddComponent<PlayController>();    // 동적으로 플레이어에 컨트롤러를 부착시켜주었다.

        //하지만 기존에 우리가 직접 넣어주었던 이동방향 한계지점 좌표같은게 동적으로 생성되었기때문에
        //설정되지않은것을 확인할수있엇다... 그래서 게임메인에 직접 넣어주기로했다.(위쪽참고)


        //this.player.leftBoundary = this.leftBoundary; //왼쪽 한계지점 설정
        //this.player.rightBoundary = this.rightBoundary;//오른쪽 한계지점 설정

        //HP,한계지점,생성위치 등등 하나하나 직접 설정해주기는 복잡해주니 이것도 한번에 Init해주도록한다.
        this.player.Init(10, this.leftBoundary, this.rightBoundary, new Vector3(0, -3.7f, 0));

        this.uiGameOver.btnRestart.onClick.AddListener(() =>
        {
            //버튼을 누르면 현재 씬을 로드
            GameMain.isGameOver = false;
            SceneManager.LoadScene("LobbyScene");
        });

        this.player.OnHit = (fillAmount) =>
        {
            this.uiGame.UpdateHpGauge(fillAmount);
        };

        this.player.OnDie = () =>
        {
            if (!GameMain.isGameOver)
            {
                GameMain.isGameOver = true;
                Debug.Log("죽었습니다.");
                this.uiGame.GameOver();
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
