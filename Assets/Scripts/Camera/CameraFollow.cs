using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Игрок или другой объект, за которым должна следовать камера
    public float smoothSpeed = 0.125f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры относительно игрока

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Желаемая позиция камеры с учетом смещения
        Vector3 targetPosition = target.position + offset;

        targetPosition.z = -10;

        // Плавное перемещение камеры к желаемой позиции
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
