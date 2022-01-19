using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UILobby : MonoBehaviour
{
    public Button[] arrBtns;
    public Action<string> onSelectedPlayer;
    //private Dictionary<int ,playerData> (���߿� ���̺��� ������ �����Ҷ� �̷��������������Ұ�)
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<arrBtns.Length; i++)
        {
            int index = i;
            Button btn = this.arrBtns[index];
            btn.onClick.AddListener(() =>
            {
                //Debug.Log(index); // <- �� Dictionary ������ Ű�� ���� �ǹ̴�.
                //���� �÷��̾� �ε��� 0 , 1 , 2���߿� �������Ѱ���
                //���������� ���� ���������� �������ߵ� (�������̸� ���� Player_01 , _02 ,_03���� �����������)
                string prefabname = string.Format("Player_0{0}", index+1); //�ε����� 0���Ͱ� �̸��� 1���ʹϱ� +1���־���.
                Debug.LogFormat("prefabName: {0}",prefabname);
                this.onSelectedPlayer(prefabname);

                //������ ĳ���͸� ���� ���� ������ ���������Ѵ�.(���� ���� ��ũ��Ʈ���� �����ϴϰű�� ����������)
                //�׷��� ���� ������ �̹� �÷��̾ ��������ִ�. �׷� �ȵǴϱ�
                //�÷��̾ ����������ϴµ� �÷��̾� ������Ʈ�� ���� �÷��̾� ��Ʈ�ѷ� ��� ��ũ��Ʈ ������Ʈ�� �������ִ�.
                //����� UI�� �����ϴ� ��ũ��Ʈ�� �ٸ������� �Ѱ��ֵ�������.
            });

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
