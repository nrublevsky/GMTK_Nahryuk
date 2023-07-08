using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject upJaw;
    public GameObject lowJaw;
    public GameObject pivot;
    public Animator animator;


    public float rotationAngleUp;
    public float rotationAngleDown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        JawControl();
    }

    public void JawControl()
    {
        if (gameManager.gameStarted)
        {
            animator.SetTrigger("startClosing");
            animator.ResetTrigger("startOpening");
        }

        if (gameManager.gameLost)
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {

            StartCoroutine(BiteFood(other.gameObject));
            //set trigger to Chewing
        }
    }

    public IEnumerator BiteFood(GameObject food)
    {
        Debug.Log("You bit! I Chew!");
        animator.SetTrigger("startChewing");
        animator.SetBool("Chewing", true);
        --gameManager.foodHp;
        gameManager.DisableBitten();
        yield return new WaitForSeconds(2);
        animator.ResetTrigger("startChewing");
        animator.SetBool("Chewing", false);
        animator.SetBool("Chewed", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("startOpening");

    }

    
}
