using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemTriggerMove : MonoBehaviour
{
    private float timeToMoveTheNextItem = 0;

    [SerializeField]
    private float timeBeforeMovingTheItem = 5;

    [SerializeField]
    protected ItemStorage storage;

    private void OnTriggerStay(Collider other)
    {
        ItemStorage inventory = other.GetComponent<ItemStorage>();
        if (inventory)
        {
            timeToMoveTheNextItem += Time.deltaTime;
            if (timeToMoveTheNextItem > timeBeforeMovingTheItem)
                if (Trigger(inventory))
                    timeToMoveTheNextItem = 0;
        }
    }

    public virtual bool Trigger(ItemStorage inventory)
    {
        return false;
    }
}
