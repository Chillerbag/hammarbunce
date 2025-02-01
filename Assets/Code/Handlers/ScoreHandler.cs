using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : LevelObject
{
    // respond to state changes, keep track of combo
    private int _currentCombo;
    private int _currentScore;

    public int CurrentScore
    {
        get => _currentScore;
        set => _currentScore = value;
    }

    public int CurrentCombo
    {
        get => _currentCombo;
        set => _currentCombo = value;
    }

    public ScoreHandler(Vector2 startPos) : base(startPos)
    {
        _currentCombo = 1;
    }

    void Start()
    {
        SubscriptionHandler.subscribe(this);
    }

    public override void OnCollisionEvent(GameObject collider1, GameObject collider2, State playerState)
    {
        if (collider1.CompareTag("Player") && collider2.CompareTag("Nail"))
        {
            if (playerState is StatePlayerSlam)
            {
                _currentScore += calcScoreOnHit(collider1);
            }
        }
    }
    
    // only need to check for angle of hammer since nail angle is always the same
    public int calcScoreOnHit(GameObject playerCollider)
    {
        // get angle of collider in 2d space
        float playerAngle = playerCollider.GetComponent<Collider>().transform.eulerAngles.z;
        
        float calcScore = Mathf.Abs((playerAngle / 270) * 100);
        
        int finalScore = (int)Mathf.Round(calcScore);

        // TODO clean this up, it is bad. 
        if (92 > finalScore || finalScore > 108)
        {
            // TODO - broadcast event to say gameover. 
            return -1; 
        }
        
        if ((finalScore < 96) || (104 < finalScore))
        {
            _currentCombo = 1;
            return finalScore;
        }
        else
        {
            _currentCombo++;
            return finalScore * _currentCombo;
        }
        // TODO - add something to say excellent and good.
    }
}
