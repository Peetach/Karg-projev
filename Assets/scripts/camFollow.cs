using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform target;       // The player
    public float smoothSpeed = 0.125f;
    public Vector3 offset;         // Camera offset

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
