using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ����� ��� ������ ������, �� ������� ������ ��������� ������
    public float smoothSpeed = 0.125f; // �������� �����������
    public Vector3 offset; // �������� ������ ������������ ������

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // �������� ������� ������ � ������ ��������
        Vector3 targetPosition = target.position + offset;

        targetPosition.z = -10;

        // ������� ����������� ������ � �������� �������
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
