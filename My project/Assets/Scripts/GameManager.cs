using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float _maxTime;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _pointsText;
    private int _points;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _timeText.text = "Time: " + _maxTime;
        _pointsText.text = "Points: 0";
        _points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _maxTime -= Time.deltaTime;
        _timeText.text = "Time: " + Mathf.FloorToInt(_maxTime);
    }

    public void UpdatePoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points;
    }
}
