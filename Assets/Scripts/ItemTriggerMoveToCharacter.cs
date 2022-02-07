using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerMoveToCharacter : ItemTriggerMove
{
    public override bool Trigger(ItemStorage inventory)
    {
        if (inventory.IsCanTakeItem() && storage.IsCanGiveItem())
        {
            inventory.TakeItem(storage.GiveItem());
            return true;
        }

        return false;
    }
}
