using UnityEngine;


public class Target : Item
{
    private int _bonusCoins;
    protected override void OnClick()
    {
        ItemSpawner.Instance.ForceCoinSpawn(_bonusCoins);
        base.OnClick();
    }

    public override void SetItem(ItemSO data)
    {
        _bonusCoins = data.bonusCoins;
        base.SetItem(data);
    }
}
