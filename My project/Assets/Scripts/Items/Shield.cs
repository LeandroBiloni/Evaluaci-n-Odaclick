using UnityEngine;

public class Shield : Item
{
    private int _hits;
    
    protected override void OnClick()
    {
        _hits--;
        PlaySound();
        if (_hits <= 0)
        {
            base.OnClick();
        }
    }
    
    public override void SetItem(ItemSO data)
    {
        _hits = data.hits;
        base.SetItem(data);
    }
}
