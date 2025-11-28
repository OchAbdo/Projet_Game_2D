using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    public Text bestScoreText;
    public AudioSource audioSource;
    public AudioClip debutSound;


    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = bestScore.ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(debutSound);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
