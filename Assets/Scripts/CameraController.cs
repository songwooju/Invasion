using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상
    public float distance = 5f; // 카메라와 대상 사이의 거리
    public float height = 2f; // 카메라의 높이
    public float sensitivity = 2f; // 마우스 감도
    public float minAngle = -30f; // 카메라 Y축 최소 회전 각도
    public float maxAngle = 60f; // 카메라 Y축 최대 회전 각도

    private float currentAngleX = 0f; // X축 회전 각도
    private float currentAngleY = 0f; // Y축 회전 각도

    private void LateUpdate()
    {
        // 마우스 입력값 받기
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 회전 각도 계산하기
        currentAngleX += mouseY;
        currentAngleY += mouseX;

        // 카메라 Y축 회전 각도 제한하기
        currentAngleX = Mathf.Clamp(currentAngleX, minAngle, maxAngle);

        // 카메라 위치 계산하기
        Vector3 targetPos = target.position - Quaternion.Euler(currentAngleX, currentAngleY, 0f) * Vector3.forward * distance;
        targetPos.y = target.position.y + height;
        transform.position = targetPos;

        // 카메라 방향 설정하기
        transform.LookAt(target);
    }
}