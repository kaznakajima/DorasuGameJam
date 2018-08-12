using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class SceneFade : SingletonMonoBehaviour<SceneFade>
{
    public static bool FinishFlg = false;

    // 透明度
    private float fadeAlpha = 0;

    // フェード中かどうか
    private bool isFadeing = false;

    // フェードの時間
    public float interval;

    // フェードの色
    Color fadeColor = Color.black;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnGUI()
    {
        // フェード中に色と透明度を更新
        if (isFadeing)
        {
            // 透明度の取得
            fadeColor.a = fadeAlpha;

            // GUIの色をfadeColorから取得
            GUI.color = fadeColor;

            // 画面比率に合わせてテクスチャを描画
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }

    // 外部からのシーン遷移
    public void LoadLevel(string scene)
    {
        if (!isFadeing)
        {
            StartCoroutine(TransScene(scene, interval));
        }
    }

    public void Delete()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    private IEnumerator TransScene(string scene, float interval)
    {
        // フェード判定
        isFadeing = true;
        FinishFlg = true;

        // intervalと比較する
        float time = 0;

        // intervalよりtimeが下なら
        while(time <= interval)
        {
            // フェード中の透明度を0 ～ 1 の間で変更
            fadeAlpha = Mathf.Lerp(0.0f, 1.0f, time / interval);

            // 音量もフェード
            SingletonMonoBehaviour<AudioManager>.Instance.myAudio.volume = Mathf.Lerp(1.0f, 0.0f, time / interval);

            // time を1フレームずつ増加
            time += Time.deltaTime;

            yield return null;
        }

        // シーンの切り替え
        SceneManager.LoadScene(scene);

        // 音楽設定
        SingletonMonoBehaviour<AudioManager>.Instance.SetAudio(scene);

        // 比較時間のリセット
        time = 0;

        // 今度は明るくしていく
        while(time <= interval)
        {
            // フェード中の透明度を1 ～ 0 の間で変更
            fadeAlpha = Mathf.Lerp(1.0f, 0.0f, time / interval);

            SingletonMonoBehaviour<AudioManager>.Instance.myAudio.volume = Mathf.Lerp(0.0f, 1.0f, time / interval);

            // time を1フレームずつ増加
            time += Time.deltaTime;

            yield return null;
        }

        // フェード判定を終了
        isFadeing = false;
        FinishFlg = false;

        // 効果音
        SingletonMonoBehaviour<AudioManager>.Instance.AudioPlay();
    }
}
