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

    private DifficultySO _difficulty;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetDifficulty(DifficultySO difficulty)
    {
        _difficulty = difficulty;
    }

    public DifficultySO GetSelectedDifficulty()
    {
        return _difficulty;
    }
}
