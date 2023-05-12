using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ���
    public float distance = 5f; // ī�޶�� ��� ������ �Ÿ�
    public float height = 2f; // ī�޶��� ����
    public float sensitivity = 2f; // ���콺 ����
    public float minAngle = -30f; // ī�޶� Y�� �ּ� ȸ�� ����
    public float maxAngle = 60f; // ī�޶� Y�� �ִ� ȸ�� ����

    private float currentAngleX = 0f; // X�� ȸ�� ����
    private float currentAngleY = 0f; // Y�� ȸ�� ����

    private void LateUpdate()
    {
        // ���콺 �Է°� �ޱ�
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // ȸ�� ���� ����ϱ�
        currentAngleX += mouseY;
        currentAngleY += mouseX;

        // ī�޶� Y�� ȸ�� ���� �����ϱ�
        currentAngleX = Mathf.Clamp(currentAngleX, minAngle, maxAngle);

        // ī�޶� ��ġ ����ϱ�
        Vector3 targetPos = target.position - Quaternion.Euler(currentAngleX, currentAngleY, 0f) * Vector3.forward * distance;
        targetPos.y = target.position.y + height;
        transform.position = targetPos;

        // ī�޶� ���� �����ϱ�
        transform.LookAt(target);
    }
}