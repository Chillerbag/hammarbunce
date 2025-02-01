using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO - implement - needs to basically just change sprite and delete collider. or make uncollidable somehow. 
public class Nail : LevelObject
{
    public Nail(Vector2 startPos) : base(startPos)
    {
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public override void OnCollisionEvent(GameObject collider1, GameObject collider2, State playerState)
    {
        throw new System.NotImplementedException();
    }
}
