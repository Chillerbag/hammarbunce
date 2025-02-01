using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LevelObject
{
    private int _moveSpeed = 10;
    private bool _didTransition = false;
    Vector2 movement = Vector2.zero;
    private Rigidbody2D _rigidbody2D; 
    private State _currentState;
    
    public Player(Vector2 startPos) : base(startPos)
    {
    }

    void Start() 
    {
        _currentState = gameObject.AddComponent<StatePlayerMove>();
        _currentState.Initialize(transform, true);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        // deal with levelEvents.
        // TODO: will the this keyword work here? 
        SubscriptionHandler.subscribe(this);
    }



    void Update() {

        // only do the stateAction if the state is active. 
        if (_currentState.GetState()) 
        {
            // spinning, or falling, or going up and spinning, or dying. 
            _currentState.stateAction();
        }

        // if the current state is a StatePlayerMove, and it is active, then we can move l and r 
        if (_currentState.moveableState && _currentState.GetState()) 
        {
            // logic for left and right movement plus slam. 
            controls();
        }

    }


    // function here for moving left and right, and changing state to slam
    public void controls() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move left in air 
            movement.x = (transform.right * (Time.deltaTime * -_moveSpeed)).x;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // move right in air 
            movement.x = (transform.right * (Time.deltaTime * _moveSpeed)).x;
            
        }
        movement += (Vector2)(transform.position);
        _rigidbody2D.MovePosition(movement);

        if (Input.GetKey(KeyCode.Space))
        {
            // enter slam state.
            // note - on exiting slam state we should gradually begin falling again and spinning once we reach the peak
            // this will probably be handled by Unity's rigidbody 2D. 
            
            _didTransition = _currentState.EndState(false);
            if (_didTransition)
            {
                State nextState = new StatePlayerSlam(); 
                _currentState.toNextState(gameObject, _currentState, nextState);
                _didTransition = false;
            }
        }

    }
    
    // COLLISION FUNCTION HERE - 
    // on collision, we check what we collided with. If its a nail, and curstate is slam, calc score event.
    // else, we call EndState(true) which handles our death logic. 
    public override void OnCollisionEvent(GameObject collider1, GameObject collider2, State playerState)
    {
        // for nail 
        if (collider1 == gameObject && collider2.CompareTag("Nail"))
        {
            if (playerState is StatePlayerSlam)
            {
                // TODO function to calc score here. (Angle of hitboxes)
                _currentState.EndState(false);
                // TODO: Slam the nail in here. (Change its sprite).
            }
            else
            {
                _currentState.EndState(true);
            }
        }
    }

}
