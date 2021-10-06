using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : Item
{
    [SerializeField] private int _bonusCoins;
    protected override void OnClick()
    {
        ItemSpawner.Instance.ForceCoinSpawn(_bonusCoins);
        base.OnClick();
    }
}
