using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {

    // Levels 1
    public int levelOneScore;
    public GameObject levelOnePanel;
    public Text levelOneScoreText;

    [Space(10)]

    // Levels 2
    public int levelTwoScore;
    public GameObject levelTwoPanel;
    public Text levelTwoScoreText;

    // Use this for initialization
    void Start () {
        levelOneScore = PlayerPrefs.GetInt("levelOneScore");
        levelOneScoreText.GetComponent<Text>().text = levelOneScore.ToString();

        levelTwoScore = PlayerPrefs.GetInt("levelTwoScore");
        levelTwoScoreText.GetComponent<Text>().text = levelTwoScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void levelOnePanelClose()
    {
        levelOnePanel.SetActive(false);
    }

    public void loadLevelOnePanel()
    {
        levelOnePanel.SetActive(true);
    }

    public void loadLevelOne()
    {
        Application.LoadLevel("levelOne");
    }

    public void levelTwoPanelClose()
    {
        levelTwoPanel.SetActive(false);
    }

    public void loadLevelTwoPanel()
    {
        levelTwoPanel.SetActive(true);
    }

    public void loadLevelTwo()
    {
        Application.LoadLevel("levelTwo");
    }
}
