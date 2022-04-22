using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dispatch;

namespace GameMode {
    public class GameController : MonoBehaviour
    {
        EventsGroup Dispatch = new EventsGroup();
        public GameObject[] hazards;
        public Vector3 spawnValues;
        public int Lives;
        public float spawnWait;
        public float startWait;
        public float waveWait; 

        public Text scoreText;
        public Text restartText;
        public Text gameOverText;

        private bool gameOver;
        private bool restart;
        private int score;

        void Start ()
        {
            gameOver = false;
            restart = false;
            restartText.text = "";
            gameOverText.text = "";
            score = 0;
            UpdateScore ();
            StartCoroutine (SpawnWaves ());


            Dispatch.Add("Add_Score", AddScore);

            Dispatch.StartListening();
        }

        void Update ()
        {
            if (restart)
            {
                if (Input.GetKeyDown (KeyCode.R))
                {
                    Application.LoadLevel (Application.loadedLevel);
                }
            }
        }

        IEnumerator SpawnWaves ()
        {
            yield return new WaitForSeconds (startWait);
            while (true)
            {
                for (int i = 0; i < Lives; i++)
                {
                    GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate (hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds (spawnWait);
                }
                yield return new WaitForSeconds (waveWait);

                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
            }
        }

        public void AddScore ()
        {
            score += EventManager.GetInt("Add_Score");
            UpdateScore ();
        }

        void UpdateScore ()
        {
            scoreText.text = "Score: " + score;
        }

        public void GameOver ()
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }

        void OnDestroy()
        {
            Dispatch.StopListening();
        }

    }

}
