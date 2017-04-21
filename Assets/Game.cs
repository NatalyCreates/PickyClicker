using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static Game Instance;

    internal int timerSecs;
    float gameStartTime;
    internal bool coolMode;
    bool gameStarted;
    internal int score;

    public GameObject bluePref, redPref;

    float loopy = 1f;
    float modeTimer = 0f;


    void Awake()
    {
        Instance = this;
        timerSecs = 60;
        coolMode = true;
        gameStartTime = 0f;
        gameStarted = false;
        score = 0;
    }

	void Start () {
		
	}

    public void StartGame()
    {
        gameStartTime = Time.time;
        gameStarted = true;
    }
	
	void Update () {
        if (gameStarted)
        {
            timerSecs = 60 + (int)(gameStartTime - Time.time);
            loopy += Time.deltaTime;
            if (loopy >= 0.5f)
            {
                loopy = 0f;
                float xPos = 0f;
                int xposrand = Random.Range(0, 3);
                if (xposrand == 0)
                {
                    xPos = 0f;
                }
                else if (xposrand == 1)
                {
                    xPos = -5f;
                }
                else if (xposrand == 2)
                {
                    xPos = 5f;
                }

                int col = Random.Range(0, 2);
                if (col == 0)
                {
                    Debug.Log("A");
                    Instantiate(redPref, new Vector3(xPos, 5f, 0f), Quaternion.identity);
                }
                else if (col == 1)
                {
                    Debug.Log("B");
                    Instantiate(bluePref, new Vector3(xPos, 5f, 0f), Quaternion.identity);
                }
            }
            if (timerSecs >= 50f)
            {
                coolMode = true;
            }
            if (timerSecs < 50f && timerSecs >= 40f)
            {
                coolMode = false;
            }
            if (timerSecs < 40f && timerSecs >= 30f)
            {
                coolMode = true;
            }
            if (timerSecs < 30f && timerSecs >= 20f)
            {
                coolMode = false;
            }
            if (timerSecs < 20f && timerSecs >= 10f)
            {
                coolMode = true;
            }
            if (timerSecs < 10f)
            {
                coolMode = false;
            }

        }
        if (timerSecs <= 0)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("done");
        }
    }
}
