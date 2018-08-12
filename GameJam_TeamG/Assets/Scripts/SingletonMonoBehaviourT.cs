using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
            }

            return instance;
        }
    }

    // インスタンス生成
    protected void Awake()
    {
        CheckInstance();
    }

    // インスタンスが存在するかチェック
    protected bool CheckInstance()
    {
        if(instance == null)
        {
            instance = (T)this;
            return true;
        }
        else if (instance == this)
        {
            return true;
        }

        // すでにインスタンスがあるなら削除 
        Destroy(gameObject);
        return false;
    }
}
