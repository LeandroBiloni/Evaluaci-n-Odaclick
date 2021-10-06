using UnityEngine;

public class Shield : Item
{
    [SerializeField] private int _hits;
    
    protected override void OnClick()
    {
        _hits--;
        PlaySound();
        if (_hits <= 0)
        {
            base.OnClick();
        }
    }
}
