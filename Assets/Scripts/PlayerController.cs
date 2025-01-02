using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPaddleController
{
    [SerializeField]
    private bool isPlayer1;
    private string axisName;
    private PaddleComponent paddle;

    void Start()
    {
        paddle = GetComponent<PaddleComponent>();
        axisName = isPlayer1 ? "VerticalPlayer1" : "VerticalPlayer2";
    }

    void Update()
    {
        HandleInput();
    }

    public void HandleInput() {
        float movement = Input.GetAxis(axisName);
        paddle.Move(movement);
    }

    public void ResetPosition()
    {
        paddle.ResetPosition();
    }
}
