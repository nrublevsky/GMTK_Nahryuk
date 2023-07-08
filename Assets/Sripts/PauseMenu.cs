using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public static bool GamePaused=false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
        
        if (GamePaused) 
            {
                Resume();

            }
            else 
            { 
            Pause();   
            
            }
        }
    }

    public void Resume() 
    
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }


    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
