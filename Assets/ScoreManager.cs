using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static ScoreManager instance;

    int score = 0;

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    public void AddPoints(int points){
        score += points;
        scoreText.text = score.ToString() + " POINTS";
    }

}
