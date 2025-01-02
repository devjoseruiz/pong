using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player1Paddle;
    [SerializeField]
    private GameObject player2Paddle;
    [SerializeField]
    private GameObject player1Goal;
    [SerializeField]
    private GameObject player2Goal;
    [SerializeField]
    private Text player1ScoreText;
    [SerializeField]
    private Text player2ScoreText;
    [SerializeField]
    private GameObject ball;

    private int player1Score;
    private int player2Score;
    private PaddleComponent player1PaddleComponent;
    private PaddleComponent player2PaddleComponent;
    private BallController ballController;

    void Start()
    {
        player1PaddleComponent = player1Paddle.GetComponent<PaddleComponent>();
        player2PaddleComponent = player2Paddle.GetComponent<PaddleComponent>();
        ballController = ball.GetComponent<BallController>();
        
        GoalTrigger player1GoalTrigger = player1Goal.GetComponent<GoalTrigger>();
        GoalTrigger player2GoalTrigger = player2Goal.GetComponent<GoalTrigger>();
        
        player1GoalTrigger.onGoalTriggered.AddListener(OnPlayer2Scored);
        player2GoalTrigger.onGoalTriggered.AddListener(OnPlayer1Scored);

        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();
    }

    void OnPlayer1Scored()
    {
        player1Score++;
        ResetRound();
    }

    void OnPlayer2Scored()
    {
        player2Score++;
        ResetRound();
    }

    void ResetRound()
    {
        player1PaddleComponent.ResetPosition();
        player2PaddleComponent.ResetPosition();
        ballController.ResetPosition();
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
}
