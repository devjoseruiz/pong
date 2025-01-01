using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7.0f;
    private Vector2 startPos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        Launch();
    }

    void Update()
    {
        
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Launch();
    }
}
