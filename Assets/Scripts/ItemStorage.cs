using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField]
    private Transform pointToMoveItem;

    [SerializeField]
    protected int sizeStorageItems = 10;

    protected int itemsCount = 0;

    [SerializeField]
    protected List<ItemGameObject> items;

    public bool IsCanGiveItem()
    {
        return items.Count > 0;
    }
    public bool IsCanGiveItem(ItemSO itemType)
    {
        return items.Exists(x => x.ItemType == itemType);
    }

    public ItemGameObject GiveItem()
    {
        if (!IsCanGiveItem()) return null;


        ItemGameObject item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);

        itemsCount--;

        OffsetObjects();

        return item;
    }

    public ItemGameObject GiveItem(ItemSO itemType)
    {
        if (!IsCanGiveItem(itemType)) return null;

        ItemGameObject item = items.Find(x => x.ItemType == itemType);
        items.Remove(item);

        itemsCount--;

        OffsetObjects();

        return item;
    }

    public bool IsCanTakeItem()
    {
        return itemsCount < sizeStorageItems;
    }


    public void TakeItem(ItemGameObject item)
    {
        //if (!IsCanTakeItem()) return;


        item.SetMove(pointToMoveItem, this, ItemPositionOffset(itemsCount));

        itemsCount++;

        OffsetObjects();
    }

    protected virtual Vector3 ItemPositionOffset(int itemsCount)
    {
        return new Vector3(itemsCount % 5, 0, itemsCount / 5);
    }

    public void MoveToStorageComplete(ItemGameObject item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            OffsetObjects();
        }
    }

    private void OffsetObjects()
    {
        int count = 0;
        foreach (ItemGameObject item in items)
        {
            item.SetMove(pointToMoveItem, this, ItemPositionOffset(count));
            count++;
        }
    }
}
