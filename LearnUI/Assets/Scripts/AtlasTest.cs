using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class AtlasTest : MonoBehaviour
{
    public Image img0;
    //public Image img1;
    public SpriteAtlas atlas;
    // Start is called before the first frame update
    void Start()
    {
       Sprite sp = atlas.GetSprite("Icon_ItemIcon_Sword_A");
        img0.sprite = sp;
        img0.SetNativeSize();//���ϸ� ��׷�����...�̹�������� �°� �����Ϸ��� ������Ѵ�.

        /*img1.sprite = sp;
        img1.SetNativeSize();*/

        //img.rectTransform.sizeDelta = new Vector2(50, 50); //�ڱⰡ ���ϴ»���� �����Ϸ��� �̷������� ����

        //ratio(����)�� ������ �����ϴ¹��������
        /*var ratio = 0.5f;
        var width = img1.rectTransform.sizeDelta.x * ratio;
        var height = img1.rectTransform.sizeDelta.y * ratio;
        img1.rectTransform.sizeDelta = new Vector2(width, height);*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
