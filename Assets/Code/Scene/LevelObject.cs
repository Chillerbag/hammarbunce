using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelObject: MonoBehaviour, IEntity {

    private Vector2 startPos;

    public LevelObject(Vector2 startPos) 
    {
        this.startPos = startPos;
    }

    // method called by sceneBuilder to set position of all LevelObjects in scene
    public void onLevelStart()
    {
        transform.position = startPos;

    }
}