using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnAllPointsChallenge : MonoBehaviour
{
    public ParticleSystem bloodParticle;
    public PuzzleManager puzzle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        StartCoroutine(ClickCheck());
       

    }

    public IEnumerator ClickCheck() {
        int position = puzzle.clickOnObjectsChallange.IndexOf(gameObject);
        Instantiate(bloodParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        puzzle.clickOnObjectsChallange.RemoveAt(position);
        puzzle.CheckClickState();
        yield return new WaitForSeconds(2f);
        Destroy(bloodParticle);
    }
}
