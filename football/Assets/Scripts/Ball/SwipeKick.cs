using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeKick : MonoBehaviour
{

    #region private variables

    private float startTouchTime, finishTouchTime, timeInterval;
    private Vector2 startPos, endPos, direction;

    [SerializeField]
    private float force = 0.2f;
    
    #endregion

    public bool isSwiped = false;

    void FixedUpdate()
    {
        if (!isSwiped)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
                startTouchTime = Time.time;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                finishTouchTime = Time.time;

                timeInterval = finishTouchTime - startTouchTime;

                endPos = Input.GetTouch(0).position;

                direction = startPos - endPos;

                if (timeInterval < 0.1)
                {
                    isSwiped = false;
                }
                else
                {

                    GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * force);
                    isSwiped = true;
                }
            }

            
        }
        

    }
}
