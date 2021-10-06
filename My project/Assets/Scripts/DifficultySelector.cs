using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    };
    
    public static DifficultySelector Instance;

    private Difficulty _difficulty;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                _difficulty = Difficulty.Easy;
                break;
            case "Medium":
                _difficulty = Difficulty.Medium;
                break;
            case "Hard":
                _difficulty = Difficulty.Hard;
                break;
        }
    }

    public Difficulty GetSelectedDifficulty()
    {
        return _difficulty;
    }
}
