using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject jaws;
    public GameObject food;
    public List<GameObject> foodParts;
    public Animator jawsAnimator;
    public Animator foodAnimator;
    public Animator gmAnimator;

    [Header("Lives")]
    public int jawsHp;
    public int foodHp;

    [Header("GameStates")]
    public bool gameStarted;
    public bool puzzleFailed;
    public bool gameWon;
    public bool gameLost;

    [Header("Variables")]
    public Vector3[] jPositions1;
    public Vector3[] jPositions2;
    public Vector3[] jPositions3;

    public Vector3 puzzlePos;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayGame();
    }

    void PlayGame()
    {
        //select random puzzle from puzzles list and instantiate in required position
        if (gameStarted)
        {
            gmAnimator.SetInteger("timesMoved", foodHp);
            if (foodHp <= 0)
            {
                gameLost = true;
                Debug.Log("you lose");
                //display you lose text
                //start 
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                PuzzleFinished();
            }
        }
    }

    public void DisableBitten()
    {
        int currLastIndex = foodParts.Count - 1;
        foodParts[currLastIndex].SetActive(false);
        foodParts.RemoveAt(currLastIndex);

    }

    public void PuzzleFinished()
    {
        Debug.Log("Puzzle Done! Fight Back!!!");
        foodAnimator.SetTrigger("HitBack");

    }
}
