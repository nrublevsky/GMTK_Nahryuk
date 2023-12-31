using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

    public GameObject gameoverScreen;
    public GameObject youWonScreen;
    private PuzzleManager puzzleManager;
    public TextMeshProUGUI livesText;
    //public GameObject MustPressKeys;
    public GameManager gameManagerScript;    // Start is called before the first frame update

    public void Start()
    {
        /*puzzleManager = GameObject.Find("ClickPuzzle").GetComponent<PuzzleManager>();*/
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        livesText.text = "HP: " + gameManagerScript.foodHp;
        if (gameManagerScript.gameLost) 
        {
            GameOver();


        }

        if (gameManagerScript.gameWon) 
        {
            GameWon();


        }
       /* if (puzzleManager.mustPressKeys) 
        { 
        
        MustPressKeys.SetActive(true);
        }*/
       /* if(!puzzleManager.mustPressKeys) 
        { 
        
        MustPressKeys.SetActive(false);
        }*/
    }
    public void Retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*puzzleManager.challengeDone = false;
        puzzleManager.challanegeIsInProgress = true;
        puzzleManager.timerOn = false;*/

    }
    public void ReturnToMenu() 
    
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver() 
    {
       /* puzzleManager.challengeDone = false;
        puzzleManager.challanegeIsInProgress = false;
        puzzleManager.timerOn = false;*/
        gameoverScreen.SetActive(true);
        /*Time.timeScale = 0f;*/

        

    }

    public void GameWon() 
    { 
    youWonScreen.SetActive(true);
    
    }
}
