using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string highScoreString = "HighScore";

    public int highScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreString, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreString, value);
        }
    }

    public int currentScore { get; set; }

    public bool isInitialized { get; set; }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        currentScore = 0;
        isInitialized = false;
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void GoToGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

}
