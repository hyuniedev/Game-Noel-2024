using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager instance;
    private GameManager(){}

    public int indexBuildScreen = SceneManager.GetActiveScene().buildIndex;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public event Action OnPlayerDeath;
    public event Action OnPlayerCompleted;
    public event Action OnPlayerJumped;

    public void EventJumped()
    {
        OnPlayerJumped?.Invoke();
    }

    public void EventDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public void EventCompleted()
    {
        OnPlayerCompleted?.Invoke();
    }
    
    public void NextLevel()
    {
        indexBuildScreen += 1;
        if (indexBuildScreen == 7)
        {
            indexBuildScreen = 0;
        }
        SceneManager.LoadScene(indexBuildScreen);
        
    }
}