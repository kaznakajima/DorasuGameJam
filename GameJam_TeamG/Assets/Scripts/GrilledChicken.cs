using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrilledChicken : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        transform.DOScale(new Vector3(1.0f, 0, 0), 1.0f).OnComplete(()=>
        {
            Destroy(gameObject);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
