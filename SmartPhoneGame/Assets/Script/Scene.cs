using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    public static bool timerStop;
    public GameObject Clear = null;
    
    public void StartButtonClicked()
    {
        AudioSource click = GetComponent<AudioSource>();
        click.Play();
        SceneManager.LoadScene("Cafe");
    }

    public void TitleButtonClicked()
    {
        AudioSource click = GetComponent<AudioSource>();
        click.Play();
        SceneManager.LoadScene("Title");
    }

    public void Stage2Button()
    {
        timerStop = false;
        SceneManager.LoadScene("City");
    }

    public void Stage3Button()
    {
        timerStop = false;
        SceneManager.LoadScene("House");
    }

    public void ScoreButton()
    {
        SceneManager.LoadScene("Ending");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        timerStop = true;

        if (Clear != null)
        {
            Clear.SetActive(true);
        }
        

        if (SceneManager.GetActiveScene().name == "House")
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
