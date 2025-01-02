using UnityEngine;

public class PaddleComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f;
    private Rigidbody2D rb;
    private Vector2 startPos;

    public float Speed => speed;
    public Rigidbody2D Rigidbody => rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(rb.velocity.x, direction * speed);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
