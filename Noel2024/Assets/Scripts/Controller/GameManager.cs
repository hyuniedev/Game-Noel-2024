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

    public void NextLevel()
    {
        SceneManager.LoadScene(indexBuildScreen + 1);
        indexBuildScreen += 1;
    }
}