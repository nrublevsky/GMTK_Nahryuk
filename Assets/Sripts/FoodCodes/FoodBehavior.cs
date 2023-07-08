using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{

    public GameObject hand;
    public Animator animator;

    public BoxCollider hitBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HitBack() { 
        
        int random = Random.Range(0, 3);

        animator.SetInteger("RandomPath", random);
        animator.SetTrigger("HitBack");

        animator.SetBool("Hitted", true);
        yield return new WaitForSeconds(0.03f);

        animator.ResetTrigger("HitBack");
        animator.SetBool("Hitted", false);
    }
}
