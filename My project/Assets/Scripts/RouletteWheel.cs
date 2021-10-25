using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteWheel
{    
    public ItemSO Calculate(Dictionary<ItemSO, int> actions)
    {
        int totalWeight = 0;

        foreach (KeyValuePair<ItemSO, int> item in actions)
        {
            totalWeight += item.Value;
        }

        int random = Random.Range(0, totalWeight);

        foreach (KeyValuePair<ItemSO, int> item in actions)
        {
            random -= item.Value;

            if (random <= 0)
            {
                return item.Key;
            }
        }
        return null;
    }
}
