using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    // Fields
    protected Transform entityTransform;
    private bool activeState;
    private bool _canMove;

    // Initialization method (replaces constructor)
    public void Initialize(Transform entityTransform, bool moveableState)
    {
        this.entityTransform = entityTransform;
        this._canMove = moveableState;
        activeState = true;
    }

    // Property for moveableState
    public bool moveableState
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    // End the current state
    public bool EndState(bool didDie)
    {
        if (didDie)
        {
            // TODO: Implement death logic.
        }
        activeState = false;
        // flag to say we have finished the state transition
        return endStateAction();
    }

    // Check if the state is active
    public bool GetState()
    {
        return activeState;
    }

    // Abstract methods to be implemented by child classes
    public abstract void stateAction();
    public abstract bool endStateAction();
    public abstract State toNextState(GameObject objectToChange, State oldState, State newState);
}