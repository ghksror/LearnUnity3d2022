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
            //ĳ���͸� ������� �κ� > ���� ����ȯ
            //SceneManager.LoadScene("GameScene"); // �ε���� �Ұ�� ���������� ����ȴ�. �̷���� �ε����� �����Ǳ⶧����
                                                 // ���Ӹ��ο��� �̰��� ������ �����������Եȴ�. �׷��� �񵿱������� �����ؾ��Ѵ�.
                                                 // (�ƿ� ���ϴ°Ǿƴ� ����ã�Ƽ� �Ҽ����ִ� .Find�� ���Ͽ�)
                                                 
            AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");//�񵿱� ��� �޼��带 ���� Async Operation�̶�°�
                                                                                //��ȯ�ϴ°� Ȯ���Ҽ��ִ�.
            operation.completed += (oper) => 
            {
                GameMain gameMain = GameObject.FindObjectOfType<GameMain>(); //���� �ε�� ������ ���� Ȱ��ȭ�Ǳ��������̴�.(�װ� LoadSceneAsync)
                gameMain.Init(prefabName);                                   // �ε尡 �ƴ� = �޸𸮿� �ö󰬴�.
                                                                   // �޸𸮿� �ö󰬴� = �� �ȿ��ִ� <GameMain>�̶�� ������Ʈ�� �����̰����ϴ�.
            };

        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
