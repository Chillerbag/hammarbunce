using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MenuObject: MonoBehaviour {

    private Vector2 startPos;

    public MenuObject(Vector2 startPos) 
    {
        this.startPos = startPos;
    }

    // method called by sceneBuilder to set position of all LevelObjects in scene
    public void onStart()
    {
        transform.position = startPos;

    }
}