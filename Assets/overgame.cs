using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class overgame : MonoBehaviour
{
    public Text ScoreText;
    public AudioSource audioSource;
    public AudioClip overSound;


    void Start()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        ScoreText.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(overSound);
    }


    public void ReStartGame()
    {
        SceneManager.LoadScene("Game");
    }




}
