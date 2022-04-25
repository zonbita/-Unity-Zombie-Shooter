using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dispatch;
using System;

public class GameManager : Singleton<GameManager>
{
    EventsGroup Dispatch = new EventsGroup();

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int Lives;
    public float spawnWait;
    public float startWait;
    public float waveWait; 

    public Text scoreText;
    public Text HP_Text;
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
        score = 0; Update_Score ();
        StartCoroutine (SpawnWaves ());
        
        //Dispatch.Add("Add_Score", AddScore);
        //Dispatch.StartListening();
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
                GameObject hazard = hazards[UnityEngine.Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3 (UnityEngine.Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
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

    public void AddScore (int number)
    {
        score += number;
        Update_Score();
    }

    void Update_Score()
    {
        scoreText.text = "Score: " + score;
    }

    public void Update_HP(int hp){
        Debug.Log(hp);
        HP_Text.text = "" + hp;
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
