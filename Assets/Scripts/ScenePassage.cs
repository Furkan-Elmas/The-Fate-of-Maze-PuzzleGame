using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePassage : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(3);
    }
    public void GameMenu()
    {
        SceneManager.LoadScene(1);
    }
}
