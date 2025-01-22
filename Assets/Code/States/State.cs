using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    // constructor - takes player transform to be used
    protected Transform entityTransform;

    public State(Transform entityTransform)
    {
        this.entityTransform = entityTransform;
    }


    public abstract void stateMovement();

    public abstract void endStateAction();

    public abstract void toNextState();
}