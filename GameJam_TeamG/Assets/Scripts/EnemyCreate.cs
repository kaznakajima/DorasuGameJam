using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    // 生成するオブジェクト
    [SerializeField]
    private GameObject birdObj; 

	// Use this for initialization
	void Start () {
        StartCoroutine(EnemySpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 敵の生成コルーチン
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(1.0f);

        // 生成位置をランダムで生成(X座標のみ)
        for(int i = 0; i< 4; i++)
        {
            float randomX;
            randomX = Random.Range(-10.0f, 10.0f);
            Instantiate(birdObj, new Vector3(randomX, transform.position.y, 0.0f), Quaternion.identity);
        }

        StartCoroutine(EnemySpawn());
    }
}
