using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorageCharacter : ItemStorage
{
    protected override Vector3 ItemPositionOffset(int intemCount)
    {
        return new Vector3(0, intemCount, 0);
    }
}
