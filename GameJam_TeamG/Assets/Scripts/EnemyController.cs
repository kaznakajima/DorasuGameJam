using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ターゲットの座標
    Vector3 TargetPos = new Vector3(0.0f, -5.0f, 0.0f);

    // 敵の正面位置
    Vector3 movePos;

    //  敵の座標
    Vector3 enemyPos;

    // 敵の移動スピード
    [HideInInspector]
    public float moveSp;

    // 角度検出
    float dy, dx, rad;

    // 焼き鳥用オブジェクトの参照
    public GameObject grilledObj;

	// Use this for initialization
	void Start () {
        moveSp = Random.Range(1.0f, 3.0f);
        TargetPos.x = Random.Range(-8.0f, 8.0f);
        enemyPos = transform.position;
        movePos = TargetPos - enemyPos;
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMove();
	}

    // オブジェクト間の角度を取得
    float GetAim()
    {
        dx = movePos.x;
        dy = movePos.y;
        rad = Mathf.Atan2(dy, dx);

        return rad * Mathf.Rad2Deg;
    }

    // 敵の移動アクション
    void EnemyMove()
    {
        // 移動方向を取得
        movePos = TargetPos - transform.position;
        // 移動方向に向く
        transform.eulerAngles = new Vector3(0, 0, GetAim());
        transform.position += movePos * moveSp *  Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // ダメージ処理
        if(col.gameObject.name == "Life")
        {
            // ライフが0より減らないようにする。
            if(SingletonMonoBehaviour<GameMaster>.Instance.gameLife > 0 && 
                SingletonMonoBehaviour<GameMaster>.Instance.castGameTime > 0)
            {
                SingletonMonoBehaviour<GameMaster>.Instance.Damage();
            }
            
            Destroy(gameObject);
        }
    }
}
