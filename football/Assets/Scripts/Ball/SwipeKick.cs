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

            if (Input.touchCount > 0)
            {

                Touch t = Input.touches[0];

                if (t.phase == TouchPhase.Began)
                {
                    startPos = Input.GetTouch(0).position;
                    //startTouchTime = Time.time;
                }

                if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
                {
                    //finishTouchTime = Time.time;

                    //timeInterval = finishTouchTime - startTouchTime;

                    endPos = Input.GetTouch(0).position;

                    direction = startPos - endPos;

                    Vector2 rbForce = -direction / force; //timeInterval * force;

                    if ((Mathf.Abs(rbForce.x) <= 5 && Mathf.Abs(rbForce.y) <= 5)) //(timeInterval < 0.1 || (Mathf.Abs(rbForce.x) <= 5 && Mathf.Abs(rbForce.y) <= 5) )
                    {
                        isSwiped = false;
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().AddForce(rbForce);
                        isSwiped = true;
                    }
                }
            }

        }
        

    }
}
