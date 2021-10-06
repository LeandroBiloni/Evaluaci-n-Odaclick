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

    public Difficulty difficulty;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
}
