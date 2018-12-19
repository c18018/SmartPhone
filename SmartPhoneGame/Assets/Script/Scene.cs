using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    static bool openTF;
    
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "Cafe")
        {
            SceneManager.LoadScene("City");
        }

        if (SceneManager.GetActiveScene().name == "City")
        {
            SceneManager.LoadScene("House");
        }

        if (SceneManager.GetActiveScene().name == "House")
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
