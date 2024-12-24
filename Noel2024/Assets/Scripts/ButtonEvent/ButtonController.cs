using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject HowToPlayCanvas;
    [SerializeField] private GameObject ShowSceneCanvas;
    [SerializeField] private RectTransform  ButtonPlay;
    private Vector2 startPosition = new Vector2(-300,150);
    private Vector2 endPosition = new Vector2(300,-150);
    private void Start()
    {
        HowToPlayCanvas.SetActive(false);
        ShowSceneCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HowToPlayCanvas.SetActive(false);
            ShowSceneCanvas.SetActive(false);
        }
    }

    public void HowToPlay()
    {
        HowToPlayCanvas.SetActive(true);
        ShowSceneCanvas.SetActive(false);
    }

    public void ShowSceneChooseLevel()
    {
        HowToPlayCanvas.SetActive(false);
        ShowSceneCanvas.SetActive(true);
    }
    public void PlayButton()
    {
        ButtonPlay.anchoredPosition = RandomBetweenTwoVectors(startPosition, endPosition);
    }

    public void ChooseLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    private Vector2 RandomBetweenTwoVectors(Vector2 min, Vector2 max)
    {
        float randomX = Random.Range(min.x, max.x); // Random giữa min.x và max.x
        float randomY = Random.Range(min.y, max.y); // Random giữa min.y và max.y
        return new Vector2(randomX, randomY); // Trả về Vector2 ngẫu nhiên
    }

}
