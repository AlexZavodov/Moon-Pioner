using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour
{
    private Vector3 itemPositionOffset;
    private ItemStorage nextItemStorage;
    private bool isMove = false;
    public ItemSO ItemType { get; private set; }

    public static ItemGameObject Create(ItemSO itemSO, Building creator, ItemStorage storage)
    {
        if (!storage.IsCanTakeItem()) return null;

        Transform transform = Instantiate(itemSO.Prefab, creator.transform.position, Quaternion.identity, creator.transform);

        ItemGameObject item = transform.GetComponent<ItemGameObject>();
        item.ItemType = itemSO;

        storage.TakeItem(item);

        return item;
    }

    public void Update()
    {
        Vector3 pointToMove = transform.parent.position + itemPositionOffset;
        if (Vector3.Distance(transform.position, pointToMove) > 0.5 && isMove)
        {
            transform.position = Vector3.Lerp(transform.position, pointToMove, Time.deltaTime * 5);
        }
        else
        if (Vector3.Distance(transform.position, pointToMove) < 0.5 && isMove)
        {
            transform.position = pointToMove;

            nextItemStorage.MoveToStorageComplete(this);
            isMove = false;
        }

        if (transform.rotation != Quaternion.identity)
        {
            transform.rotation = Quaternion.identity;
        }
    }

    public void SetMove (Transform newParent, ItemStorage nextItemStorage, Vector3 itemPositionOffset)
    {

        transform.SetParent(newParent);
        isMove = true;
        this.nextItemStorage = nextItemStorage;
        this.itemPositionOffset = itemPositionOffset;
    }
}
