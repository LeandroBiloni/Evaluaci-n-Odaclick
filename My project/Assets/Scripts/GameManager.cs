using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float _maxTime;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private int _pointsToWin;
    private int _points;
    
    [SerializeField] private DifficultySO _easyDifficultySo;
    [SerializeField] private DifficultySO _mediumDifficultySo;
    [SerializeField] private DifficultySO _hardDifficultySo;

    private DifficultySO _selectedDifficulty;
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

        DifficultySettings();
        
        ItemSpawner.Instance.SpawnItem();

        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    private void DifficultySettings()
    {
        switch (DifficultySelector.Instance.difficulty)
        {
            case DifficultySelector.Difficulty.Easy:
                _selectedDifficulty = _easyDifficultySo;
                break;
            case DifficultySelector.Difficulty.Medium:
                _selectedDifficulty = _mediumDifficultySo;
                break;
            case DifficultySelector.Difficulty.Hard:
                _selectedDifficulty = _hardDifficultySo;
                break;
        }

        if (_selectedDifficulty != null)
        {
            foreach (var item in _selectedDifficulty.itemList)
            {
                ItemSpawner.Instance.AddSpawnChances(item.itemPrefab, item.weight);
            }
        }
    }

    IEnumerator SpawnTimer()
    {
        var time = Random.Range(_selectedDifficulty.minSpawnTime, _selectedDifficulty.maxSpawnTime);

        yield return new WaitForSeconds(time);
        
        ItemSpawner.Instance.SpawnItem();

        StartCoroutine(SpawnTimer());
    }
    
    public void UpdatePoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points;
        
        if (_points >= _pointsToWin)
            Debug.Log("win");
    }

    private void UpdateTime()
    {
        _maxTime -= Time.deltaTime;
        _timeText.text = "Time: " + Mathf.FloorToInt(_maxTime);
        
        if (_maxTime <= 0)
            Debug.Log("lose");
    }

    public DifficultySO GetSelectedDifficulty()
    {
        return _selectedDifficulty;
    }
}
