using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayerMove : State
{
    

    public override void stateAction() 
    {
        // this will need to be dynamic. change rotation speed with combo 
        entityTransform.eulerAngles = Vector3.forward * 1;
    }

    public override bool endStateAction()
    {
        // stop rotation 

        // is this actually useless? - cleanup later.
        return true;

    }

    public override State toNextState(GameObject objectToChange, State oldState, State newState)
    {
        State _newState = null; 
        if (newState is StatePlayerSlam)
        {
            Destroy(oldState as MonoBehaviour);
            _newState = objectToChange.AddComponent<StatePlayerSlam>();
            (_newState as StatePlayerSlam).Initialize(objectToChange.transform, false);
            
        }
        
        return _newState;
    }
}