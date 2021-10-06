using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float _maxTime;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private int _pointsToWin;
    private int _points;
    
    [SerializeField] private DifficultySO _easyDifficultyData;
    [SerializeField] private DifficultySO _mediumDifficultyData;
    [SerializeField] private DifficultySO _hardDifficultyData;

    private DifficultySO _selectedDifficultyData;
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
        switch (DifficultySelector.Instance.GetSelectedDifficulty())
        {
            case DifficultySelector.Difficulty.Easy:
                _selectedDifficultyData = _easyDifficultyData;
                break;
            case DifficultySelector.Difficulty.Medium:
                _selectedDifficultyData = _mediumDifficultyData;
                break;
            case DifficultySelector.Difficulty.Hard:
                _selectedDifficultyData = _hardDifficultyData;
                break;
        }

        if (_selectedDifficultyData != null)
        {
            foreach (var item in _selectedDifficultyData.itemList)
            {
                ItemSpawner.Instance.AddSpawnChances(item.itemPrefab, item.weight);
            }
        }
    }

    IEnumerator SpawnTimer()
    {
        var time = Random.Range(_selectedDifficultyData.minSpawnTime, _selectedDifficultyData.maxSpawnTime);

        yield return new WaitForSeconds(time);
        
        ItemSpawner.Instance.SpawnItem();

        StartCoroutine(SpawnTimer());
    }
    
    public void UpdatePoints(int points)
    {
        _points += points;
        _pointsText.text = "Points: " + _points;

        if (_points >= _pointsToWin)
            SceneController.Instance.LoadWin();
    }

    private void UpdateTime()
    {
        _maxTime -= Time.deltaTime;
        _timeText.text = "Time: " + Mathf.FloorToInt(_maxTime);

        if (_maxTime <= 0)
            SceneController.Instance.LoadLose();
    }

    public DifficultySO GetSelectedDifficultyData()
    {
        return _selectedDifficultyData;
    }
}
