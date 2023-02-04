using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

    private const string kApplePickerHighScore = "kApplePickerHighScore";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(kApplePickerHighScore))
        {
            score = PlayerPrefs.GetInt(kApplePickerHighScore);
        }

        PlayerPrefs.SetInt(kApplePickerHighScore, score);
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "high Score:" + score;
        if (score > PlayerPrefs.GetInt(kApplePickerHighScore)) 
        {
            PlayerPrefs.SetInt(kApplePickerHighScore, score);
        }
    }

}
