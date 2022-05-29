using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    int countdown = 300;
    public Text countdown_TEXT;
    void Start()
    {
        InvokeRepeating("Time", 1, 1);
    }

    void Time()
    {
        countdown--;
        countdown_TEXT.text = "" + countdown;
    }
}
