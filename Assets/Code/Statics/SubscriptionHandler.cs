using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubscriptionHandler
{
    private static List<menuObject> menuSubscribers;

    private static List<levelObject> levelSubscribers;

    public static void subscribe<T>(T subscriber) 
    {
        if (subscriber is menuObject menuSub) 
        {
            menuSubscribers.Add(menuSub);
        } 
        else if (subscriber is levelObject levelSub) 
        {
            levelSubscribers.Add(levelSub);
        }
    }
}
