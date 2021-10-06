using System.Collections;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private string _itemName;
    
    [SerializeField] protected int _points;

    [SerializeField] protected int _pointsToReduceOnDestroy;

    [SerializeField] private float _aliveTimer;

    [SerializeField] private AudioClip _clip;
    
    private float _myTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeOut());
    }

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
        yield return new WaitForSeconds(_aliveTimer);
        GameManager.Instance.UpdatePoints(-_pointsToReduceOnDestroy);
        Destroy(gameObject);
    }

    
    protected virtual void OnClick()
    {
        GameManager.Instance.UpdatePoints(_points);
        StopCoroutine(TimeOut());

        PlaySound();
        
        Destroy(gameObject);
    }

    public string GetItemName()
    {
        return _itemName;
    }
    
    protected void PlaySound()
    {
        if (_clip != null)
            AudioPlayer.Instance.PlaySound(_clip);
    }
}
