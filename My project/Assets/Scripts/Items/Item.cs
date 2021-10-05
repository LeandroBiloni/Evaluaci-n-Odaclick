using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] 
    protected int _points;

    [SerializeField] private float _aliveTimer;
    
    
    private float _myTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, _aliveTimer);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.UpdatePoints(_points);
            Destroy(gameObject);
        }
    }
}
