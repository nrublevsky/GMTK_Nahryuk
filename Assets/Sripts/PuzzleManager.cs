using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<GameObject> clickOnObjectsChallange;
    public bool challengeDone;
    public bool challanegeIsInProgress;
    public float puzzleObjectsCount;
    // Start is called before the first frame update
    void Start()
    {
        challengeDone = false;
        challanegeIsInProgress = true;
    }

    // Update is called once per frame
    void Update()

    {
     
        
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
            Debug.Log("Challenge Done");
        
        }
    }
}
