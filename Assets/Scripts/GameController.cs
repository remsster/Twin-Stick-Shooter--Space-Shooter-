using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController ThisInstance;
    public static int Score;
    public string ScorePrefix = string.Empty;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;

    private void Awake()
    {
        ThisInstance = this;
    }

    private void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
    }

    public static void GameOver()
    {
        if (ThisInstance.GameOverText != null)
        {
            ThisInstance.GameOverText.gameObject.SetActive(true);
        }
    }

}
