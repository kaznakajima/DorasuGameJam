﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        // メインシーンのロード
        SingletonMonoBehaviour<SceneFade>.Instance.LoadLevel("main");
    }
}