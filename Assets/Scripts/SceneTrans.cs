using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneTrans : MonoBehaviour
{
    public AudioSource voice;
    float volume = 0f;
    public GameObject Setting_panel;

    void Start()
    {
        voice.Play();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Playing()
    {
        SceneManager.LoadScene(2);
    }
    public void Helping()
    {
        SceneManager.LoadScene(6);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Settings()
    {
        Setting_panel.SetActive(true);
    }
    public void Exit()
    {
        Setting_panel.SetActive(false);
    }

    public void Main_Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        voice.volume = volume;
    }
    public void volumechange(float value)
    {

        volume = value;
        DontDestroyOnLoad(voice);
    }
}