using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausem : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
         pauseMenu.SetActive(false); 
         Time.timeScale = 1;
    }
    
     public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // pause du jeu
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // reprend le jeu
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
