﻿using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour
{
    GameObject targetObj;
    Vector3 targetPos;

    void Start()
    {
        
    }

    void Update()
    {

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
    }

}