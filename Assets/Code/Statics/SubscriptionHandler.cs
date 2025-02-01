using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: menu subscription events for buttons being clicked. 

public static class SubscriptionHandler
{
    private static List<MenuObject> menuSubscribers;

    private static List<LevelObject> levelSubscribers;

    public static void subscribe<T>(T subscriber) 
    {
        if (subscriber is MenuObject menuSub) 
        {
            menuSubscribers.Add(menuSub);
        } 
        else if (subscriber is LevelObject levelSub) 
        {
            levelSubscribers.Add(levelSub);
        }
    }

    public static void unsubscribe<T>(T subscriber)
    {
        if (subscriber is MenuObject menuSub) 
        {
            menuSubscribers.Remove(menuSub);
        } 
        else if (subscriber is LevelObject levelSub) 
        {
            levelSubscribers.Remove(levelSub);
        }
    }
    
    public static void NotifyLevelSubscribers(GameObject collider1, GameObject collider2, State playerState)
    {
        foreach (var subscriber in levelSubscribers)
        {
            subscriber.OnCollisionEvent(collider1, collider2, playerState);
        }
    }
    
}
