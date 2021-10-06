using UnityEngine;


public class Target : Item
{
    [SerializeField] private int _bonusCoins;
    protected override void OnClick()
    {
        ItemSpawner.Instance.ForceCoinSpawn(_bonusCoins);
        base.OnClick();
    }
}
