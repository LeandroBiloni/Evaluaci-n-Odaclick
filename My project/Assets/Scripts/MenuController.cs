using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void SetDifficulty(string difficulty)
    {
        DifficultySelector.Instance.SetDifficulty(difficulty);

        SceneController.Instance.LoadGame();
    }
}
