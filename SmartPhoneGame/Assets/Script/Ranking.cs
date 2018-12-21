using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour {

    public Text scoreText;
    public Text[] rankingText;

    float secondScore;
    public int score = 0;

    int rank1;
    int rank2;
    int rank3;

    void Start()
    {
        secondScore = Battery.seconds1 + Battery.seconds2 + Battery.seconds3;
        score = Mathf.RoundToInt(secondScore * 100);

        //PlayerPrefs.DeleteAll();

        rank1 = PlayerPrefs.GetInt("first", 0);
        rank2 = PlayerPrefs.GetInt("second", 0);
        rank3 = PlayerPrefs.GetInt("third", 0);

        if (score > rank1)
        {
            rank3 = rank2;
            rank2 = rank1;
            rank1 = score;
            PlayerPrefs.SetInt("first", rank1);
            PlayerPrefs.SetInt("second", rank2);
            PlayerPrefs.SetInt("third", rank3);
        }else if(score > rank2)
        {
            rank3 = rank2;
            rank2 = score;
           PlayerPrefs.SetInt("second", rank2);
            PlayerPrefs.SetInt("third", rank3);
        }else if(score > rank3)
        {
            rank3 = score;
            PlayerPrefs.GetInt("third", rank3);
        }

        scoreText.text = score.ToString();
        rankingText[0].text = rank1.ToString();
        rankingText[1].text = rank2.ToString();
        rankingText[2].text = rank3.ToString();
    }
}
