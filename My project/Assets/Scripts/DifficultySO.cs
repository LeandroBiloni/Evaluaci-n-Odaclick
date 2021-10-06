using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Create Difficulty Setting")]
public class DifficultySO : ScriptableObject
{
    public List<ItemSO> itemList = new List<ItemSO>();
    public float minSpawnTime;
    public float maxSpawnTime;
    public int minObjectsToSpawn;
    public int maxObjectsToSpawn;
}
