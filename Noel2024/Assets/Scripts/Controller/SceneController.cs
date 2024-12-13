using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    private void Start()
    {
        levelText.text = "Level: " + (GameManager.Instance.indexBuildScreen + 1);
    }
    private void Update()
    {
        if (PlayerMovement.IsDead && Input.anyKeyDown)
        {
            SceneManager.LoadScene(GameManager.Instance.indexBuildScreen);
            Time.timeScale = 1;
        }
    }
}
