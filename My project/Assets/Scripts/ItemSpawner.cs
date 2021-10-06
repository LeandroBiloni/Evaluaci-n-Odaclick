using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private float _timeToSpawn;

    private float _timeSinceLastSpawn;
    
    [SerializeField] private bool _spawnOnlyCoins;

    private int _spawnedCoinsCounter;
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnItem();
    }

    private void SpawnItem()
    {
        Item item = null;
        if (_spawnOnlyCoins)
        {
            if (_spawnedCoinsCounter > 0)
            {
                _spawnedCoinsCounter--;

                if (_spawnedCoinsCounter <= 0)
                {
                    _spawnOnlyCoins = false;
                }
                foreach (var i in _items)
                {
                    if (i.GetItemName() != "Coin") continue;
            
                    item = i;
                    break;
                }
            }
        }
        else
        {
            var random = Random.Range(0, _items.Count);
            item = _items[random];
        }
        
        if (item)
            Spawn(item);
    }

    private void Spawn(Item item)
    {
        var i = Instantiate(item, _spawnContainer);
        var res = Screen.currentResolution;
        float xPostiion = Random.Range(-(res.width / 2) + 100, (res.width / 2) - 100);
        float yPostiion = Random.Range(-(res.height / 2) + 100, (res.height / 2) - 100);
        Vector3 randomPos = new Vector3(xPostiion, yPostiion, 0);
        i.transform.localPosition = randomPos;
    }

    public void ForceCoinSpawn(int amount)
    {
        _spawnOnlyCoins = true;
        _spawnedCoinsCounter = amount;
    }
}
