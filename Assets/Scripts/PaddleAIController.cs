using UnityEngine;

public class PaddleAIController : MonoBehaviour, IPaddleController
{
    private PaddleComponent paddle;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private float reactionDelay = 0.025f;
    [SerializeField]
    private float maxPredictionError = 0.45f;
    private Transform ballTransform;

    void Start()
    {
        paddle = GetComponent<PaddleComponent>();
        ballTransform = ball.transform;
    }

    void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        float direction = CalculateMovement();
        paddle.Move(direction);
    }

    private float CalculateMovement()
    {
        float targetY = ballTransform.position.y + Random.Range(-maxPredictionError, maxPredictionError);
        float deltaY = Mathf.Lerp(0, targetY - transform.position.y, 1 - reactionDelay);
        return Mathf.Clamp(deltaY, -1f, 1f);
    }

    public void ResetPosition()
    {
        paddle.ResetPosition();
    }
}
