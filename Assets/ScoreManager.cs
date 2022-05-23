using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;

    public static ScoreManager instance;

    int score = 0;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        scoreText2.text = score.ToString() + " POINTS";
        scoreText3.text = score.ToString() + " POINTS";
    }

    public void AddPoints(int points){
        score += points;
        scoreText.text = score.ToString() + " POINTS";
        scoreText2.text = score.ToString() + " POINTS";
        scoreText3.text = score.ToString() + " POINTS";
    }

}
