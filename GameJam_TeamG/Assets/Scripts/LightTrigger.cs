using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    AudioSource myAudio;

	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 当たり判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bird")
        {
            SingletonMonoBehaviour<GameMaster>.Instance.BirdCount();
            SingletonMonoBehaviour<AudioManager>.Instance.OtherAudioPlay(myAudio);
            GameObject grilledObj = Instantiate(col.GetComponent<EnemyController>().grilledObj, col.gameObject.transform);
            grilledObj.transform.parent = null;
            Destroy(col.gameObject);
        }
    }
}
