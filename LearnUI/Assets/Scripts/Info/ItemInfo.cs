using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public int id;
    public int count;

    //������
    public ItemInfo(int id, int count = 1)
    {
        this.id = id;
        this.count = count;
    }

}
