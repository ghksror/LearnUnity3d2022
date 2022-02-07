using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class UIInventory : MonoBehaviour
{
    public UIItem[] uiItems;
    public SpriteAtlas atlas;

    private ItemInfo uiItemInfo;

    //UIInventory가 아틀라스 인스턴스를 참조해야함(화면에 디스플레이해야하기때문) ,필드를만들고 어싸인
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
                //화면에 디스플레이
                Sprite sp = atlas.GetSprite(itemData.spriteName);
                uiItem.Init(sp, uiItemInfo);
            }
        }*/

        //순회
        /*for(int i =0; i<itemInfos.Length; i++)
        {
            UIItem uiItem = uiItems[i];
            ItemInfo uiItemInfo = itemInfos[i];

            ItemData itemData = dic[uiItemInfo.id];
            

            //화면에 디스플레이
            Sprite sp = atlas.GetSprite(itemData.spriteName);

            uiItem.Init(sp);
        }*/

        
    }
}
