using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    private string _name = "%NaN%";

    [SerializeField]
    private Transform prefab;


    public Transform Prefab
    {
        get
        {
            return prefab;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }
}
