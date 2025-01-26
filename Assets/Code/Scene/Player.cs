using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    // note: become a subscriber here.

    
    private State currentState;

    void Start() 
    {
        currentState = new StatePlayerMove(transform);

    }



    void Update() {

        // hammer state 
        currentState.stateMovement();

        // if the current state is a StatePlayerMove then we can move l and r 
        if (currentState is StatePlayerMove canMoveState) {
            // logic for left and right movement...

        }

    }


    // function here for moving left and right, and changing state to slam
    public void controls() {

    }

}
