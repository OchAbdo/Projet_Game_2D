using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class overgame : MonoBehaviour
{
    public Text ScoreText;


    void Start()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        ScoreText.text = score.ToString();
    }


    public void ReStartGame()
    {
        SceneManager.LoadScene("Game");
    }




}
