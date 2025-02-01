using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class LevelObject: MonoBehaviour {

    private Vector2 _startPos;

    public LevelObject(Vector2 startPos) 
    {
        _startPos = startPos;
    }

    // method called by sceneBuilder to set position of all LevelObjects in scene
    public void onStart()
    {
        transform.position = _startPos;

    }
    
    public abstract void OnCollisionEvent(GameObject collider1, GameObject collider2, State playerState);
}