using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else Instance = this;
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }
    
    public void LoadLose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
