﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour {

    public float secondCons;
    float seconds;
    public static float seconds1 = 0;
    public static float seconds2 = 0;
    public static float seconds3 = 0;
    public Slider battery;
    public GameObject player;
    public GameObject GoFilter;

    private void Start()
    {
        seconds = secondCons + 1.0f;
    }


    void Update () {
        //　バッテリーがゼロになったらゲームオーバーObjを出す
        if (seconds <= 0) scene();

        if(seconds > 0)
        {
            countDown();
        }


        if (SceneManager.GetActiveScene().name == "Cafe")
        {
            seconds1 = seconds;
        }else if (SceneManager.GetActiveScene().name == "City")
        {
            seconds2 = seconds;
        }else if (SceneManager.GetActiveScene().name == "House")
        {
            seconds3 = seconds;
        }
    }


    //　バッテリーを一秒ごとに減らす。
    void countDown()
    {
        if (Scene.timerStop == false)
        {
            seconds -= Time.deltaTime;
            battery.value = seconds / secondCons;
        }
    }


    // プレイヤーの動きを止める　２秒後にGameOverを呼ぶ
    void scene()
    {
        player.SendMessage("moveF");
        Invoke("GameOver", 2.0f);
    }


    // ゲームオーバーObjを出す
    void GameOver()
    {
        GoFilter.gameObject.SetActive(true);
    }
}
