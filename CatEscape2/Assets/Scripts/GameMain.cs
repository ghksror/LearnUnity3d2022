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
    
    //public GameObject[] playerPrefabs; //���� �������� ����� �ϱ� ����...
    //������ ���� �ε��ϴ� �� ���������־���. Assets/Resources���� ���� (�������� �̸�����������)
    //Resources�̸��� ���� �������� ������ Resources.Load �Լ��� ���� ���� �Ҽ����ִ�.
    //�������� ���� �ȿ��ְ� ã���ֱ⸸�ϸ� ���� ��������ʿ䰡 ���ٴ¶�. (�������� �ε��Ҽ��ִ�.)

    // Start is called before the first frame update
    void Start() //�Ʒ� Init�� ���� ����ǹǷ� �׳� �� �Ű��־���.
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

    //Init �� ���� void Start���� ���� ȣ��Ǳ⶧���� start�� ���ʿ䰡����.
    public void Init(string prefabName)
    {
        var targetPrefab = this.dicPrefabs[prefabName];

        //���ο� �÷��̾ �������Ѵ� <= �������� �ν��Ͻ�ȭ�ؾ��Ѵ�.
        //������ ���� ���Ӹ��ο����� �������� �����������ʴ�. �κ񿡼� ���������� �׷��� �װ� �־�����Ѵ�.

        //�������� �ν��Ͻ�ȭ
        
        GameObject playerGo = Instantiate(targetPrefab);  //�÷��̾ �ҷ��ü������� �ҷ��� �÷��̾�� ��Ʈ�ѷ��� ���� �����Ǿ������ʴ�.


        //playerGo.transform.position = new Vector3(0, -3.7f, 0); //ĳ���� ���� ������ ����

        this.player = playerGo.AddComponent<PlayController>();    // �������� �÷��̾ ��Ʈ�ѷ��� ���������־���.

        //������ ������ �츮�� ���� �־��־��� �̵����� �Ѱ����� ��ǥ������ �������� �����Ǿ��⶧����
        //���������������� Ȯ���Ҽ��־���... �׷��� ���Ӹ��ο� ���� �־��ֱ���ߴ�.(��������)


        //this.player.leftBoundary = this.leftBoundary; //���� �Ѱ����� ����
        //this.player.rightBoundary = this.rightBoundary;//������ �Ѱ����� ����

        //HP,�Ѱ�����,������ġ ��� �ϳ��ϳ� ���� �������ֱ�� �������ִ� �̰͵� �ѹ��� Init���ֵ����Ѵ�.
        this.player.Init(10, this.leftBoundary, this.rightBoundary, new Vector3(0, -3.7f, 0));

        this.uiGameOver.btnRestart.onClick.AddListener(() =>
        {
            //��ư�� ������ ���� ���� �ε�
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
                Debug.Log("�׾����ϴ�.");
                this.uiGame.GameOver();
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
