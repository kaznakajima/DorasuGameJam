using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCheck : MonoBehaviour
{
    // ハイスコア表示用Text
    public Text highScoreTex;

	// Use this for initialization
	void Start () {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Clear":
                highScoreTex.text = string.Format("HIGH SCORE : " + PlayerPrefs.GetInt("highScore").ToString());
                break;
            case "GameOver":
                highScoreTex.text = string.Format("今回のスコア : " + PlayerPrefs.GetInt("currentScore").ToString());
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
