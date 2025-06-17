using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private float speedX;
    private float speedY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");

    }

    void FixedUpdate()
    {

        
        // Yön varsa dön
        Vector2 direction = new Vector2(speedX, speedY);
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle -90;
        }
        Vector2 moveVelocity = new Vector2(speedX, speedY).normalized * moveSpeed;
        rb.linearVelocity = moveVelocity;
    }
}
