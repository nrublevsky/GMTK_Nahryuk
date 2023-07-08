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
        OpenJaw();
    }

    public void OpenJaw()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("startClosing");
            animator.ResetTrigger("startOpening");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("startOpening");
            animator.ResetTrigger("startClosing");
        }
    }
}
