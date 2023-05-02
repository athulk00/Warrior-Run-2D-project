using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool gameIsPaused;
    public GameObject pauseMenuUI;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;


    }
    public void pause()
    {

        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameIsPaused = true;

    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void rePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
