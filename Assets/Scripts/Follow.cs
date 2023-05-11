using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float sensitivity = 5.0f; // ���콺 ����

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;

        // Y �� ȸ���� ���� ���� (-90 ~ 90��)
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);

        // ȸ���� ����
        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0);
    }
}
