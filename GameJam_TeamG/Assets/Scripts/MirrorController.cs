using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MirrorController : MonoBehaviour
{
    // 回転速度
    [HideInInspector]
    public float RotateSpeed;

    // 角度制限
    [HideInInspector]
    public float XMaxRadian, XMinRadian;

    // 回転ベクトル
    [HideInInspector]
    public Vector3 C_Rotate;

    // 入力ベクトル
    public Vector3 CalcRotate;

    // カメラオフセットの空オブジェクト
    public GameObject RotateOffset;

    // Use this for initialization
    void Start()
    {
        // 回転オフセットを作成
        RotateOffset = new GameObject("CameraOffset");

        // オフセット座標を自身の座標にする
        RotateOffset.transform.position = transform.position;

        // オフセットオブジェクトの子にする
        transform.parent = RotateOffset.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraAngle();
    }

    // 角度調整
    private void CameraAngle()
    {
        // コントローラーの入力情報を取得
        CalcRotate = new Vector3(0, 0,  -Input.GetAxisRaw("Mouse X"));

        // 回転角度を加算
        C_Rotate += CalcRotate * RotateSpeed;

        // 角度制限
        C_Rotate.z = Mathf.Clamp(C_Rotate.z, XMinRadian, XMaxRadian);

        // カメラの回転
        RotateOffset.transform.eulerAngles = C_Rotate;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(MirrorController))]
public class MirrorControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // インスタンス化
        MirrorController Edit = target as MirrorController;

        EditorGUILayout.LabelField("カメラの回転速度");
        Edit.RotateSpeed = EditorGUILayout.Slider("Slider", Edit.RotateSpeed, 0.0f, 10.0f);

        EditorGUILayout.MinMaxSlider(new GUIContent("カメラの角度制限"), ref Edit.XMinRadian, ref Edit.XMaxRadian, -90.0f, 90.0f);
        Edit.XMaxRadian = EditorGUILayout.Slider("XMaxRadian", Edit.XMaxRadian, -90.0f, 90.0f);
        Edit.XMinRadian = EditorGUILayout.Slider("XMinRadian", Edit.XMinRadian, -90.0f, 90.0f);

        EditorGUILayout.LabelField("MinDistance = ", Edit.XMinRadian.ToString());
        EditorGUILayout.LabelField("MaxDistance = ", Edit.XMaxRadian.ToString());
    }
}
#endif
