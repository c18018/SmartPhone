using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour {

    public float secondCons;
    public static float seconds;
    public Slider battery;
    public GameObject player;
    public GameObject GoFilter;

	void Start () {
        if (SceneManager.GetActiveScene().name == "Cafe")
        {
            seconds = secondCons;
        }
	}
	
	void Update () {
        if (seconds <= 0) scene();
        if(seconds > 0)
        {
            seconds -= Time.deltaTime;
            battery.value = seconds / secondCons;
        }
	}

    void scene()
    {
        player.SendMessage("moveF");
        Invoke("GameOver", 2.0f);
    }

    void GameOver()
    {
        GoFilter.gameObject.SetActive(true);
    }
}
