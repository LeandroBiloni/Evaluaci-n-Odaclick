using Unity.VisualScripting;
using UnityEngine;
using System;

public class Target : Item
{
    private int _bonusCoins;
    private ItemSO _itemForClickEffect;
    protected override void OnClick()
    {
        base.OnClick();
        FindObjectOfType<ItemSpawner>().AddItemToPool(_itemForClickEffect, _bonusCoins);
    }

    public override void SetItem(ItemSO data)
    {
        base.SetItem(data);
        _bonusCoins = data.bonusCoins;
        _itemForClickEffect = data.itemForClickEffect;
    }
}
