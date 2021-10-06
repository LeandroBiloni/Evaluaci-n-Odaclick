using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private string _itemName;
    
    [SerializeField] 
    protected int _points;

    [SerializeField] private float _aliveTimer;
    
    
    private float _myTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeOut());
    }

    private void OnMouseOver()
    {
        Debug.Log("mouse over " + _itemName);
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(_aliveTimer);
        GameManager.Instance.UpdatePoints(-1);
        Destroy(gameObject);
    }

    protected virtual void OnClick()
    {
        GameManager.Instance.UpdatePoints(_points);
        StopCoroutine(TimeOut());
        Destroy(gameObject);
    }

    public string GetItemName()
    {
        return _itemName;
    }
}
