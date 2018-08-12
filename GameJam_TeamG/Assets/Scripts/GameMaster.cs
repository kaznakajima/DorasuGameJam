using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : SingletonMonoBehaviour<GameMaster>
{
    // 残機用オブジェクト
    public GameObject[] lifeObj;

    // 残り残機
    [HideInInspector]
    public int gameLife = 3;

    // 残り時間
    float gameTime = 10;
    [HideInInspector]
    public int castGameTime = 10;
    // 時間表示用Text
    public Text timeTex;

    // 焼き鳥のカウント数
    [HideInInspector]
    public int countNum;

    // 焼き鳥のカウント数表示用テキスト
    public Text countTex;

    // Use this for initialization
    void Start () {
        countTex.text = countNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間がなくなったら早期リターン
        if(castGameTime < 1)
        {
            // ハイスコアだったら格納
            if (PlayerPrefs.GetInt("highScore") < countNum)
                PlayerPrefs.SetInt("highScore", countNum);

            SingletonMonoBehaviour<SceneFade>.Instance.LoadLevel("Clear");

            return;
        }

        CountDown();
    }

    // 時間経過メソッド
    void CountDown()
    {
        gameTime -= 1 * Time.deltaTime;
        castGameTime = (int)gameTime;
        timeTex.text = castGameTime.ToString();
    }

    // スコア加算メソッド
    public void BirdCount()
    {
        // スコア加算し、Textに反映
        countNum++;
        countTex.text = countNum.ToString();
    }

    // ダメージメソッド
    public void Damage()
    {
        gameLife--;
        lifeObj[gameLife].SetActive(false);
        // 残機が0ならゲームオーバー
        if(gameLife == 0)
        {
            PlayerPrefs.SetInt("currentScore", countNum);
            SingletonMonoBehaviour<SceneFade>.Instance.LoadLevel("GameOver");
        }
    }
}
