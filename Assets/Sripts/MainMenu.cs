using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
   public void PlayGameEasy() 
    {
        SceneManager.LoadScene("NickTestScene");
    
    }

    public void PlayGameMedium() 
    {
        SceneManager.LoadScene("Medium");
    
    }

    public void PlayGameHard() 
    {

        SceneManager.LoadScene("Hard");
    }

    public void Quit() 
    { 
    Application.Quit();
    
    }
}
