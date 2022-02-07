using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorageInBuilding : ItemStorage
{
    public bool IsCompleteMoveAllNeededItems(List<ItemSO> itemTypes)
    {
        foreach (ItemSO itemType in itemTypes)
        {
            if (!IsCanGiveItem(itemType))
                return false;
        }

        return true;
    }

    public void DestroyAllNeededItems()
    {
        foreach(ItemGameObject item in items)
        {
            Destroy(item.gameObject);
        }

        itemsCount = 0;
        items.Clear();
    }
}
