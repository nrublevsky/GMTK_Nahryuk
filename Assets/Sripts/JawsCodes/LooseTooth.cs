using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTooth : MonoBehaviour
{
    public List<GameObject> teeth;
    public GameManager gManager;
    public Animator animator;

    public int teethToLose;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TestTeeth();
    }

    void TestTeeth()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(LooseToothy(teethToLose));
        }
    }
    public IEnumerator LooseToothy(int nTeeth)
    {

        int localN = 1;

        while (localN != nTeeth)
        {
            GameObject tInQuestion = RandomTooth(teeth);
            tInQuestion.transform.parent = null;
            Rigidbody tRb = tInQuestion.GetComponent<Rigidbody>();
            tRb.useGravity = true;
            tRb.velocity = new Vector3(Random.Range(-1, 1)*speed, Random.Range(-1, 1)*speed, -1);
            ++localN;
            --gManager.jawsHp;
            teeth.Remove(tInQuestion);
            yield return new WaitForSeconds(0.001f);
        }
        animator.SetTrigger("getHurt");
    }

    public GameObject RandomTooth(List<GameObject> tees)
    {
        int rand = Random.Range(0, tees.Count - 1);
        return tees[rand];
    }


}