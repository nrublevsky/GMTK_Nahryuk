using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTooth : MonoBehaviour
{
    public List<GameObject> teeth;
    public GameManager gManager;
    public Animator animator;
    public Animator gMAnimator;

    public int teethToLose;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HurtTeeth()
    {
        StartCoroutine(LooseToothy(teethToLose));
    }

    public IEnumerator LooseToothy(int nTeeth)
    {

        int localN = Random.Range(1, teethToLose);

        while (localN != nTeeth)
        {
            GameObject tInQuestion = RandomTooth(teeth);

            tInQuestion.transform.parent = null;
            Rigidbody tRb = tInQuestion.GetComponent<Rigidbody>();

            tRb.useGravity = true;

            tRb.velocity = new Vector3(Random.Range(-1, 1) * speed, Random.Range(-1, 1) * speed, -1);

            ++localN;
            --gManager.jawsHp;

            teeth.Remove(tInQuestion);

            yield return new WaitForSeconds(0.001f);
        }
        gMAnimator.SetTrigger("moveBack");
        gMAnimator.SetBool("moved", true);
        animator.SetTrigger("getHurt");
        yield return new WaitForSeconds(2f);
        gMAnimator.SetBool("moved", false);
    }

    public GameObject RandomTooth(List<GameObject> tees)
    {
        int rand = Random.Range(0, tees.Count - 1);
        return tees[rand];
    }


}
