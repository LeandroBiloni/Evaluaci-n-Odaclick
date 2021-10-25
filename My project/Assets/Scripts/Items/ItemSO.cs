using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create Item")]
public class ItemSO : ScriptableObject
{
    public Item itemPrefab;
    public string itemName;
    public int points;
    public int pointsToReduceOnDestroy;
    public float aliveTime;
    public AudioClip soundEffect;

    [Header("Used by Shield")] public int hits;

    [Header("Used by Target")] public int bonusCoins;
    public int weight;
}
