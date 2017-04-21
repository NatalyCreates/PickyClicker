using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public GameObject tutorialBox, timerUI, scoreUI, colorUI;

    void Awake()
    {
        tutorialBox.SetActive(true);
    }
    void Start () {
        StartCoroutine("ShowIntro");
	}
	
    IEnumerator ShowIntro()
    {
        yield return new WaitForSeconds(6f);
        tutorialBox.SetActive(false);
        Game.Instance.StartGame();
    }
    
	void Update () {

        if (Game.Instance.timerSecs < 60) timerUI.GetComponent<Text>().text = "00:" + Game.Instance.timerSecs.ToString();
        scoreUI.GetComponent<Text>().text = Game.Instance.score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Game.Instance.coolMode)
        {
            colorUI.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            colorUI.GetComponent<Image>().color = Color.red;
        }

    }
}
