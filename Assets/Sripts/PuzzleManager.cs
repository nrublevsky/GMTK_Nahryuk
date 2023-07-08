using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> clickOnObjectsChallange;
    public TextMeshProUGUI gameOverText;
    
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI[] challengeText;
    public uiManager uiManager;
    private int lives;
    public bool timerOn = false;
    public Button restartButton;
    public int timeLeft;
    public bool isGameActive;
    public bool challengeDone;
    public bool challanegeIsInProgress;
    public float puzzleObjectsCount;
    public bool mustPressKeys;
    public bool keyIsPressed;
    // Start is called before the first frame update
    void Start()
    {
        challengeDone = false;
        challanegeIsInProgress = true;
        mustPressKeys = false;
        keyIsPressed = true;
        timerOn = false;
        timeLeft = Random.Range(3, 9);
        
    }

    // Update is called once per frame
    private void Update()

    {
        if (challanegeIsInProgress && !timerOn)
        {
            
            timeLeftText.text = "Time Left: " + timeLeft;
            StartCoroutine(timeTake());


        }
        if (timeLeft < 1)
        {   
            challanegeIsInProgress = false;
            timeLeft = 0;
            uiManager.GameOver();
            


        }
        

    }

    /* private Vector3 GenerateSpawnPosition() 
     {
         float spawnposX = Random.Range(336, 337);
         float spawnposY = Random.Range(168, 166);
         Vector3 randomPos = new Vector3 (spawnposX, spawnposY,-44);
         return randomPos;
     }*/

    /*void ClickableObjects(int ClickObjectsToSpawn)
    {
        int ClickObjects = Random.Range(0, 5);
        for (int i = 0; i < ClickObjectsToSpawn; i++)
        {
            Instantiate(clickOnObjectsChallange[ClickObjects], GenerateSpawnPosition(), clickOnObjectsChallange[ClickObjects].transform.rotation);
        }

    }*/

    public void CheckClickState()
    {
        if( clickOnObjectsChallange.Count.Equals(0) ) 
        
        {
            challengeDone=true;
            challanegeIsInProgress=false;
            timeLeft = Random.Range(3, 8);
            Debug.Log("Challenge Done");
        
        }


    }
    public void MustPressKeys() 
    { 
    if (mustPressKeys) 
        {
            challanegeIsInProgress = true;
        
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) 
            {
                mustPressKeys = false;
                Debug.Log("Space is pressed! Well done!");
            
            
            }
        
        
        }
    
    
    }

   IEnumerator timeTake() 
    { 
        timerOn = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        timeLeftText.text = "Time Left: " + timeLeft;
        timerOn = false;

    
    
    }
}
