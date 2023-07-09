using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMouth : MonoBehaviour
{

    public LooseTooth lt;
    public int hits;
    public JawsBehavior jaws;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mouth"))
        {
           /* if (hits == 0)
            {*/
                if (!jaws.chewingATM)
                {
                    StartCoroutine(Hit());
                }
                else
                {
                    Debug.Log("Can't hit atm< srry");
                }
                
            /*}*/
        }
    }

    public IEnumerator Hit()
    {
        Debug.Log("Hit");
        lt.HurtTeeth();
        ++hits;
        yield return new WaitForSeconds(0.5f);
        hits = 0;
        Debug.Log($"{hits} hits");
    }
}
