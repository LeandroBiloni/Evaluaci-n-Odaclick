using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    private Transform _canvas;

    private float _timeSinceLastSpawn;
    
    private bool _spawnOnlyCoins;

    private int _spawnedCoinsCounter;

    private RouletteWheel _roulette;

    private Dictionary<ItemSO, int> _itemChances = new Dictionary<ItemSO, int>();

    [SerializeField] private List<Item> _itemPool = new List<Item>();
    
    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>().transform;
    }

    private void Start()
    {
        _roulette = new RouletteWheel();
    }


    private void SpawnItem()
    {
        var minItem = GameManager.Instance.GetSelectedDifficultyData().minObjectsToSpawn;
        var maxItem = GameManager.Instance.GetSelectedDifficultyData().maxObjectsToSpawn;
        
        //Determines how many items will spawn.
        var itemsQuantity = Random.Range(minItem, maxItem + 1);

        for (int i = 0; i < itemsQuantity; i++)
        {
            if (_roulette == null)
            {
                _roulette = new RouletteWheel();
            }
            
            //Determines which item will spawn.
            var item = _roulette.Calculate(_itemChances);

            if (item)
            {
                _itemPool.Add(Spawn(item));
            }
        }
    }

    /// <summary>
    /// Spawns an item at a random screen position.
    /// </summary>
    /// <param name="itemData">The item to spawn.</param>
    private Item Spawn(ItemSO itemData)
    {
        var item = Instantiate(itemData.itemPrefab, _canvas);
        
        item.SetItem(itemData);

        item.OnClickEvent += GameManager.Instance.UpdatePoints;

        item.OnDeathEvent += GameManager.Instance.UpdatePoints;

        item.gameObject.SetActive(false);
        
        return item;
    }

    /// <summary>
    /// Sets item spawn chances to ItemSpawner.
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="weight">Higher weight in relation to other items gives more chance to spawn the item.</param>
    public void AddSpawnChances(ItemSO itemData, int weight)
    {
        _itemChances.Add(itemData, weight);
    }
    
    /// <summary>
    /// Gets the first item from the item pool.
    /// </summary>
    /// <returns></returns>
    public Item PickObjectFromPool()
    {
        Item obj = null;

        //If there is no items in the pool, new ones are created
        if (_itemPool.Count <= 0)
        {
            SpawnItem();
        }

        obj = _itemPool[0];

        _itemPool.RemoveAt(0);

        return obj;
    }

    /// <summary>
    /// Adds the given item to the pool of items.
    /// </summary>
    /// <param name="item">The item to add.</param>
    /// <param name="quantity">The quantity to add.</param>
    public void AddItemToPool(ItemSO item, int quantity = 1)
    {
        _itemPool.Clear();
        for (int i = 0; i < quantity; i++)
        {
            _itemPool.Add(Spawn(item));
        }
    }
}
