using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class UIInventory : MonoBehaviour
{
    public UIItem[] uiItems;
    public SpriteAtlas atlas;

    private ItemInfo uiItemInfo;

    //UIInventory�� ��Ʋ�� �ν��Ͻ��� �����ؾ���(ȭ�鿡 ���÷����ؾ��ϱ⶧��) ,�ʵ带����� �����
    public void Init(ItemInfo[] itemInfos, Dictionary<int,ItemData> dic)
    {
        /*for(int i=0; i<uiItems.Length; i++)
        {
            UIItem uiItem = uiItems[i];
            
            if (i > itemInfos.Length-1)
            {
                uiItemInfo = null;
                uiItem.Init(null, uiItemInfo);
            }
            else
            {
                ItemInfo uiItemInfo = itemInfos[i];
                ItemData itemData = dic[uiItemInfo.id];
                //ȭ�鿡 ���÷���
                Sprite sp = atlas.GetSprite(itemData.spriteName);
                uiItem.Init(sp, uiItemInfo);
            }
        }*/

        //��ȸ
        /*for(int i =0; i<itemInfos.Length; i++)
        {
            UIItem uiItem = uiItems[i];
            ItemInfo uiItemInfo = itemInfos[i];

            ItemData itemData = dic[uiItemInfo.id];
            

            //ȭ�鿡 ���÷���
            Sprite sp = atlas.GetSprite(itemData.spriteName);

            uiItem.Init(sp);
        }*/

        
    }
}
