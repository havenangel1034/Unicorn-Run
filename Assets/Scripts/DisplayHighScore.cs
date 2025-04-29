using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreText;

   public void UpdateHighScoreText()
    {
        highScoreText.text = $"Highscore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    private void Start()
    {
        UpdateHighScoreText();
    }

}
