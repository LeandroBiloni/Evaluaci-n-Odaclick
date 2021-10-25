using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private float _maxTime;
    [SerializeField] private int _pointsToWin;
    private int _points;

    [SerializeField] private DifficultySO _selectedDifficultyData;

    public delegate void TimeUpdate(float value);
    public event TimeUpdate OnTimeUpdateEvent;

    public delegate void PointsUpdate(int currentPoints, int maxPoints);

    public event PointsUpdate OnPointsUpdateEvent;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        _selectedDifficultyData = DifficultySelector.Instance.GetSelectedDifficulty();
        
        if (_selectedDifficultyData != null)
        {
            foreach (var itemData in _selectedDifficultyData.itemList)
            {
                ItemSpawner.Instance.AddSpawnChances(itemData, itemData.weight);
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
        
        OnPointsUpdateEvent?.Invoke(_points, _pointsToWin);
        
        if (_points >= _pointsToWin)
            SceneController.Instance.LoadWin();
    }

    private void UpdateTime()
    {
        _maxTime -= Time.deltaTime;
        OnTimeUpdateEvent?.Invoke(_maxTime);
        if (_maxTime <= 0)
            SceneController.Instance.LoadLose();
    }

    public DifficultySO GetSelectedDifficultyData()
    {
        return _selectedDifficultyData;
    }
}
