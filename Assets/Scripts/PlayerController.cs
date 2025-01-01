using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1;
    [SerializeField]
    private float speed = 3.0f;
    private Rigidbody2D rb;
    private float move;
    private string axisName;
    private Vector2 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        axisName = isPlayer1 ? "VerticalPlayer1" : "VerticalPlayer2";
    }

    void Update()
    {
        move = Input.GetAxis(axisName);
        rb.velocity = new Vector2(rb.velocity.x, move * speed);
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
