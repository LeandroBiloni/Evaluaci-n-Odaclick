using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void SetDifficulty(DifficultySO difficulty)
    {
        DifficultySelector.Instance.SetDifficulty(difficulty);

        SceneController.Instance.LoadGame();
    }
}
