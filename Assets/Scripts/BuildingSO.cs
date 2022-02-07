using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BuildingSO")]
public class BuildingSO : ScriptableObject
{
    [SerializeField]
    private Transform prefab;

    [SerializeField]
    private ItemSO product;

    [SerializeField]
    private float timeToProduct;

    [SerializeField]
    private List<ItemSO> needToProduction;

    public Transform Prefab
    {
        get
        {
            return prefab;
        }
    }

    public ItemSO Product
    {
        get
        {
            return product;
        }
    }

    public float TimeToProduct
    {
        get
        {
            return timeToProduct;
        }
    }

    public List<ItemSO> NeedToProduction
    {
        get
        {
            return needToProduction;
        }
    }
}
