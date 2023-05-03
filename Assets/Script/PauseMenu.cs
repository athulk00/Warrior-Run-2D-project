using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsPaused == false)
            {
                pause();
            }
            else 
            {
                resume();
            }
        }
    }
    public void pause()
    {

        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    public void resume()
    {
        
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;


    }
  
    public void quitGame()
    {
        Application.Quit();
    }
    public void rePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
