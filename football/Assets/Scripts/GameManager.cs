using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        #region Private fields

        [SerializeField]
        private GameObject[] ballSpawnPoints;
        [SerializeField]
        private GameObject ball;
        [SerializeField]
        private GameObject endGameUI;

        private IEnumerator timeCoroutine;

        private UIController UI;

        private bool isStarted = false;

    #endregion

        #region Public fields
        public int globGoal, globMiss;
        public int goal;
        public int miss;
        public int roundTime = 60;

        #endregion

        void Awake()
        {
            UI = GameObject.Find("UIController").GetComponent<UIController>();
            InitializeBall();
        }

        private void Start()
        {
            UI.UISetup();
            Time.timeScale = 0; 
            timeCoroutine = timeCounterCour();
            StartCoroutine(timeCoroutine);
        }

         private void Update()
         {
            if (miss == 5)
                LoseEndGame(true);
            if (goal == 5)
                LoseEndGame(false);
         }


        private IEnumerator timeCounterCour()
        {
            while(roundTime != 0)
            {
                roundTime--;
                UI.ShowTime();
                yield return new WaitForSeconds(1f);
            }
            LoseEndGame(true);

    }

        public void InitializeBall()
        {
            int randomSpawn = Random.Range(0, ballSpawnPoints.Length);
            Instantiate(ball, ballSpawnPoints[randomSpawn].transform);
        }

        public void OnGoal()
        {
            if (goal < 5)
                goal++;
            globGoal = PlayerPrefs.GetInt("globalGoal");
            globGoal++;
            PlayerPrefs.SetInt("globalGoal", globGoal);
            UI.UISetup();
            InitializeBall();
        }

        public void OnMiss()
        {
            if (miss < 5)
                miss++;
            globMiss = PlayerPrefs.GetInt("globalMiss");
            globMiss++;
            PlayerPrefs.SetInt("globalMiss", globMiss);
            UI.UISetup();
            InitializeBall();
        }

        public void LoseEndGame(bool lose)
        {
            Time.timeScale = 0;
            UI.EndGameUI(lose);
            endGameUI.SetActive(true);
        }

    }



