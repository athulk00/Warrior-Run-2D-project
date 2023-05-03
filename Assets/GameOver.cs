using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameOverUI.SetActive(true);
        }
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void rePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
