using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{

    public GameObject pinBall;
    public GameObject EndPanel;
    public GameObject scoreText;

    public float delayTime;

    public int existingScore;

    public string levelNumber;
    public string nextLevelNumber;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pinBall)
        {
            if (pinBall.GetComponent<PinBallController>().speed <= 4 && pinBall.GetComponent<PinBallController>().timeSinceInitialization >= 5)
            {
                pinBall.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                EndPanel.SetActive(true);
                StartCoroutine(CountUpScore(pinBall.GetComponent<PinBallController>().score));
            }
        }
    }

    IEnumerator CountUpScore(int score)
    {
        while (existingScore < score)
        {
            existingScore++;
            yield return new WaitForSeconds(delayTime);
            scoreText.GetComponent<Text>().text = existingScore.ToString();
        }
    }

    public void RestartLevel()
    {
        if (pinBall.GetComponent<PinBallController>().score >= PlayerPrefs.GetInt(levelNumber + "Score"))
        {
            PlayerPrefs.SetInt(levelNumber + "Score", pinBall.GetComponent<PinBallController>().score);
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void NextLevel()
    {
        if (pinBall.GetComponent<PinBallController>().score >= PlayerPrefs.GetInt(levelNumber + "Score"))
        {
            PlayerPrefs.SetInt(levelNumber + "Score", pinBall.GetComponent<PinBallController>().score);
            Application.LoadLevel(nextLevelNumber);
        }
        else
        {
            Application.LoadLevel(nextLevelNumber);
        }
    }

    public void ReturnToMenu()
    {
        if(pinBall.GetComponent<PinBallController>().score >= PlayerPrefs.GetInt(levelNumber + "Score"))
        {
            PlayerPrefs.SetInt(levelNumber + "Score", pinBall.GetComponent<PinBallController>().score);
            Application.LoadLevel("menu");
        }
        else
        {
            Application.LoadLevel("menu");
        }
    }
}
