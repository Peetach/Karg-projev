using UnityEngine;

public class okGosterme : MonoBehaviour
{
    public Transform target;
    public Transform player;

    void Update()
    {
        if (target == null) return;

         Vector3 direction = (target.position - player.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
