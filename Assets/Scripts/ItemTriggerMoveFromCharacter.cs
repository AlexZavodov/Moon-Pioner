using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerMoveFromCharacter : ItemTriggerMove
{
    [SerializeField]
    List <ItemSO> itemTypes;

    public override bool Trigger(ItemStorage inventory)
    {
        foreach (ItemSO itemType in itemTypes)
        {
            if (storage.IsCanTakeItem() && inventory.IsCanGiveItem(itemType))
            {
                storage.TakeItem(inventory.GiveItem(itemType));
                return true;
            }
        }

        return false;
    }
}
