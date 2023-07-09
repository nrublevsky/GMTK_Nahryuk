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
    public GameObject puzzleSpawn;
    public List<GameObject> puzzles;

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

    public GameObject curPuz;
    public PuzzleManager curPuzMan;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(FirstRound());
        
    }

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
        puzzleWon = false;
        curPuz = null;
        curPuzMan = null;

        foodAnimator.SetTrigger("HitBack");
        yield return new WaitForSeconds(1f);
        foodAnimator.ResetTrigger("HitBack");
        foodAnimator.SetBool("Hitted", true);
        yield return new WaitForSeconds(1f);
        foodAnimator.ResetTrigger("HitBack");
        foodAnimator.SetBool("Hitted", false);

        PutPuzzle();
    }

    public void TestHandMouth()
    {
        if (puzzleWon)
        {
            StartCoroutine(WinPuzzle());
        }
    }

    public void PutPuzzle()
    {

        if (curPuz == null)
        {
            GameObject go = CurrentPuzzle(puzzles);
            curPuz = go;
            curPuzMan = curPuz.GetComponent<PuzzleManager>();
            curPuzMan.gm = this.gameObject.GetComponent<GameManager>();
            Instantiate(go, puzzleSpawn.transform.position, puzzleSpawn.transform.rotation);
        }
    }

    public IEnumerator FirstRound()
    {

        gameStarted = true;
        /*puzzleWon = false;*/
        gameWon = false;
        gameLost = false;

        GameObject go = CurrentPuzzle(puzzles);
        curPuz = go;
        curPuzMan = curPuz.GetComponent<PuzzleManager>();
        curPuzMan.gm = this.gameObject.GetComponent<GameManager>();
        Instantiate(go, puzzleSpawn.transform.position, puzzleSpawn.transform.rotation);

        yield return null;
    }

    public GameObject CurrentPuzzle(List<GameObject> pzls)
    {
        return pzls[Random.Range(0, pzls.Count - 1)];
    }
}
