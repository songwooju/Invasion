using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float sensitivity = 5.0f; // 마우스 감도

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;

        // Y 축 회전값 범위 제한 (-90 ~ 90도)
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);

        // 회전값 적용
        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0);
    }
}
