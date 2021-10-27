using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Item : MonoBehaviour
{
    private string _itemName;
    
    protected int _points;

    protected int _pointsToReduceOnDestroy;

    private float _aliveTime;

    private AudioClip _soundEffect;
    
    private float _myTime;

    public delegate void ClickAction(int value);

    public delegate void DeathAction(int value);
    
    public event ClickAction OnClickEvent;
    
    public event DeathAction OnDeathEvent;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    /// <summary>
    /// Coroutine to destroy item.
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(_aliveTime);

        OnDeathEvent?.Invoke(-_pointsToReduceOnDestroy);

        Destroy(gameObject);
    }

    
    protected virtual void OnClick()
    {
        OnClickEvent?.Invoke(_points);
        StopCoroutine(TimeOut());

        PlaySound();
        Destroy(gameObject);
    }

    protected void PlaySound()
    {
        if (_soundEffect != null)
            AudioPlayer.Instance.PlaySound(_soundEffect);
    }

    /// <summary>
    /// Sets the item data and starts destroy timer.
    /// </summary>
    /// <param name="data"></param>
    public virtual void SetItem(ItemSO data)
    {
        _itemName = data.itemName;
        _points = data.points;
        _pointsToReduceOnDestroy = data.pointsToReduceOnDestroy;
        _aliveTime = data.aliveTime;
        _soundEffect = data.soundEffect;
    }
    
    public void StartTimer()
    {
        StartCoroutine(TimeOut());
    }
}
