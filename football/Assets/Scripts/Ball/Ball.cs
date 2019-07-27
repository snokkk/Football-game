using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Ball : MonoBehaviour
    {
        private GameManager gameManager;
        private Rigidbody2D rb;
        private bool isSwiped;
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void Update()
        {

            Vector3 vel = rb.velocity;

            isSwiped = gameObject.GetComponent<SwipeKick>().isSwiped;

            if (isSwiped && vel.magnitude < 0.1f)
            {
                Destroy(gameObject);
                gameManager.OnMiss();
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "goal")
            {
                Destroy(gameObject);
                gameManager.OnGoal();
            }

            if (collision.gameObject.tag == "goalkeeper")
            {
                Destroy(gameObject);
                gameManager.OnMiss();
            }

        }
    }
