using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerSlam : State
{
    private Rigidbody2D _rigidbody2D;
    private float _slamSpeed = 5f; // Speed at which the player slams downward
    private bool _isSlamming = false;

    public new void Initialize(Transform playerTransform, bool startState)
    {
        base.Initialize(playerTransform, startState);

        // Access the GameObject associated with the Transform and get the Rigidbody2D
        _rigidbody2D = playerTransform.gameObject.GetComponent<Rigidbody2D>();
        
        _isSlamming = true;
    }
    

    public override void stateAction()
    {
        if (!_isSlamming) return;
        
        // Apply downward force for the slam
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_slamSpeed);

        // Check if the player has hit the ground or another condition to stop slamming
        if (CheckContact())
        {
            _isSlamming = false;
        }
    }
    
    private bool CheckContact()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (hit.collider)
        {
            // Notify subscribers about the collision, passing the player state.
            SubscriptionHandler.NotifyLevelSubscribers(gameObject, hit.collider.gameObject, this);
            return true;
        }

        return false;
    }

    public override bool endStateAction()
    {
        // TODO move back up, but only if we have slammed into a nail. (respond on trigger).
        return true;

    }

    public override State toNextState(GameObject objectToChange, State oldState, State newState)
    {
        State _newState = null; 
        
        // this explictness seems bad. not sure how to fix.
        if (newState is StatePlayerMove)
        {
            Destroy(oldState as MonoBehaviour);
            _newState = objectToChange.AddComponent<StatePlayerMove>();
            (_newState as StatePlayerMove).Initialize(objectToChange.transform, false);
        }
        
        return _newState;
    }
}