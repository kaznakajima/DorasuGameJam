using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    // 自身のAudioSource
    [HideInInspector]
    public AudioSource myAudio;

    // 流す音楽
    public AudioClip[] clipList;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    // シーンごとに音楽指定
    public void SetAudio(string scene)
    {
        switch(scene)
        {
            case "Title":
                myAudio.loop = true;
                myAudio.clip = clipList[0];
                break;
            case "main":
                myAudio.loop = true;
                myAudio.clip = clipList[1];
                break;
            case "Clear":
                myAudio.loop = false;
                myAudio.clip = clipList[2];
                break;
            case "GameOver":
                myAudio.loop = false;
                myAudio.clip = clipList[3];
                break;
        }
    }

    // 音楽再生
    public void AudioPlay()
    {
        if(myAudio.loop == true)
        {
            return;
        }

        // 一度再生
        myAudio.PlayOneShot(myAudio.clip);
    }

    // 外部の音楽再生
    public void OtherAudioPlay(AudioSource otherAudio)
    {
        otherAudio.PlayOneShot(otherAudio.clip);
    }
}
