using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Football.UI;

namespace Football
{

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

        public int goal;
        public int miss;
        public int roundTime = 60;

        #endregion

        void Awake()
        {
            UI = GameObject.Find("UIController").GetComponent<UIController>();
            UI.UISetup();
            InitializeBall();
            Time.timeScale = 1;
        }

        private void Start()
        {
            timeCoroutine = timeCounterCour();
            StartCoroutine(timeCoroutine);
        }

        private void Update()
        {
                if (miss == 5)
                EndGame(true);
            if (goal == 5)
                EndGame(false);
        }


        private IEnumerator timeCounterCour()
        {
            while(roundTime != 0)
            {
                roundTime--;
                UI.ShowTime();
                yield return new WaitForSeconds(1f);
            }
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
            int globGoal = PlayerPrefs.GetInt("globalGoal");
            globGoal++;
            PlayerPrefs.SetInt("globalGoal", globGoal);
            UI.UISetup();
            InitializeBall();
        }

        public void OnMiss()
        {
            if (miss < 5)
                miss++;
            int globMiss = PlayerPrefs.GetInt("globalMiss");
            globMiss++;
            PlayerPrefs.SetInt("globalMiss", globMiss);
            UI.UISetup();
            InitializeBall();
        }

        public void EndGame(bool lose)
        {
            Time.timeScale = 0;
            UI.EndGameUI(lose);
            endGameUI.SetActive(true);

        }

    }
}


