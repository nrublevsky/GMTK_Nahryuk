using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject jaws;
    public LooseTooth ltooth;
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
    public bool puzzleWon;
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
        /*foodHp = foodParts.Count;*/
    }

    // Update is called once per frame






    public void Update()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        /*gmAnimator.SetInteger("timesMoved", foodHp);*/
        //select random puzzle from puzzles list and instantiate in required position
        if (gameStarted)
        {
            /*gmAnimator.SetInteger("timesMoved", foodHp);*/
            if (foodHp <= 0)
            {
                gameLost = true;
                gameWon = false;

                jawsAnimator.SetBool("Chewed", false);
                jawsAnimator.SetBool("Chewing", false);
                jawsAnimator.ResetTrigger("startClosing");
                jawsAnimator.ResetTrigger("startOpening");
                jawsAnimator.ResetTrigger("startChewing");
                jawsAnimator.ResetTrigger("getHurt");

                Debug.Log("you lose");
                //display you lose text

            }
            if (jawsHp <= 0)
            {
                gameWon = true;
                gameLost = false;
                Debug.Log("you win");
                //display you lose text

            }

            TestHandMouth();
        }
    }

    public void DisableBitten()
    {
        int currLastIndex = foodParts.Count - 1;
        foodParts[currLastIndex].SetActive(false);
        foodParts.RemoveAt(currLastIndex);
        gmAnimator.SetInteger("timesMoved", foodHp);
    }


    public IEnumerator WinPuzzle()
    {
        puzzleWon = true;

        foodAnimator.SetTrigger("HitBack");
        yield return new WaitForSeconds(1f);
        foodAnimator.ResetTrigger("HitBack");
        foodAnimator.SetBool("Hitted", true);
        yield return new WaitForSeconds(1f);
        foodAnimator.ResetTrigger("HitBack");
        foodAnimator.SetBool("Hitted", false);
    }

    public void TestHandMouth()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(WinPuzzle());
        }
    }
}
