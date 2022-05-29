using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplate : MonoBehaviour
{
    public GameObject maleFinishPoint, femaleFinisPoint;

    private Movement maleMovement;
    private Movement femaleMovement;

    int sayac;

    private void Start()
    {
        maleMovement = GameObject.Find("MaleCharacter").GetComponent<Movement>();
        femaleMovement = GameObject.Find("FemaleCharacter").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MaleCharacter" && transform.name == "MaleFinishPoint")
        {
            sayac = PlayerPrefs.GetInt("sayac");
            sayac++;
            PlayerPrefs.SetInt("sayac", sayac);
            maleMovement.CharacterSpeed = 0;
        }
        if (other.gameObject.name == "FemaleCharacter" && transform.name == "FemaleFinishPoint")
        {
            sayac = PlayerPrefs.GetInt("sayac");
            sayac++;
            PlayerPrefs.SetInt("sayac", sayac);
            femaleMovement.CharacterSpeed = 0;  
        }
    }
    private void Update()
    {
        if (sayac == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
