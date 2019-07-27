using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class UIController : MonoBehaviour
    {
        [Header("Score text")]
        [Space]
        [SerializeField]
        private Text goalText;
        [SerializeField]
        private Text missText;
        [SerializeField]
        private Text globalGoal;
        [SerializeField]
        private Text globalMiss;
        [SerializeField]
        private Text winLoseText;
        [SerializeField]
        private Text time;

        private GameManager gameManager;

        private void Awake()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            ShowTime();
        }

        public void ShowTime()
        {
            time.text = gameManager.roundTime + "";
        }

        public void UISetup()
        {
            goalText.text = gameManager.goal + "/5";
            missText.text = gameManager.miss + "/5";
        }

        public void EndGameUI(bool lose)
        {
            int globMiss = PlayerPrefs.GetInt("globalMiss");
            int globGoal = PlayerPrefs.GetInt("globalGoal");


            globalMiss.text = "" + globMiss;
            globalGoal.text = "" + globGoal;

            if (lose)
                winLoseText.text = "You lose :(";
            if (!lose)
                winLoseText.text = "You win!";
        }

        public void OnClickRestart()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

