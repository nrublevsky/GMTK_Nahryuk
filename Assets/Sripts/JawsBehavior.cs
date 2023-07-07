using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawsBehavior : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject upJaw;
    public GameObject lowJaw;
    public GameObject pivot;

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
        upJaw.transform.RotateAround(pivot.transform.position, Vector3.back, rotationAngleUp);
        lowJaw.transform.RotateAround(pivot.transform.position, -Vector3.back, rotationAngleDown);
    }
}
