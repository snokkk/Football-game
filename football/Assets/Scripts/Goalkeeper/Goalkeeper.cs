using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    #region Private fields

    private IEnumerator rndmCoroutine;
    private int random;
    private Animator anim;
    
    #endregion

    void Start()
    {
        rndmCoroutine = rndmSpeedChange();
        anim = gameObject.GetComponent<Animator>();
        StartCoroutine(rndmCoroutine);

    }

    private IEnumerator rndmSpeedChange()
    {
        while (true)
        {
            random = Random.Range(0, 2);
            if (random == 1)
                anim.speed = 2f;
            else anim.speed = 1f;
            yield return new WaitForSeconds(4f);
        }
        
    }

}
