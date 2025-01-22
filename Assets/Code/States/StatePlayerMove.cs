using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerMove : State
{
    public StatePlayerMove(Transform entityTransform) : base(entityTransform) { }

    public override void stateMovement() {


    }

    public override void endStateAction();

    public override void toNextState();
}