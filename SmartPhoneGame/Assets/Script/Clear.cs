using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour {

    float secondScore;
    int score = 0;

    public Text scoreText;


	void Start () {
        secondScore = Battery.seconds1 + Battery.seconds2;
        score = Mathf.RoundToInt(secondScore * 100);

        scoreText.text = "Score : " + score.ToString();
    }
}
