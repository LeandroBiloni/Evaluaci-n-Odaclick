using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create Item")]
public class ItemSO : ScriptableObject
{
    public Item itemPrefab;
    public int weight;
}
