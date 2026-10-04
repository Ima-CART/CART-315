using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1, scorePlayer2;
    public ScoreText scoreTextLeft, scoreTextRight;
    public Paddle paddle1;
    public Paddle paddle2;
    public FloatingPwUp powerUp;


    public void OnScoreZoneReached(int id)
    {

        if (id == 1)
            scorePlayer1++;

        if (id == 2)
            scorePlayer2++;

        UpdateScores();


        paddle1.transform.localScale = new Vector3(
     paddle1.transform.localScale.x,
     2f,
     paddle1.transform.localScale.z
 );

        paddle2.transform.localScale = new Vector3(
            paddle2.transform.localScale.x,
            2f,
            paddle2.transform.localScale.z
        );
        powerUp.ResetPosition();
    }


    private void UpdateScores()
    {
        scoreTextLeft.SetScore(scorePlayer1);
        scoreTextRight.SetScore(scorePlayer2);
    }
}
