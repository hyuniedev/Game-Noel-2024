using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text levelText;

    private void Start()
    {
        levelText.text = "Level: " + (GameManager.Instance.indexBuildScreen);
    }
}