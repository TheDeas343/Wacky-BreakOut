using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 

{
    static Ball invokerBall;
    static List<UnityAction> listenersBall = new List<UnityAction>();

    static List<Block> invokersPoint = new List<Block>();
    static UnityAction<int> listenerPoint;

    static LevelBuilder invokerGameOver;
    static UnityAction<int> listenerGameOver;

    public static void AddListenerBallSpawner(UnityAction handler)
    {
        listenersBall.Add(handler);

       if(invokerBall != null)
        {
            invokerBall.AddListener(handler);
        }

    }

    public static void AddInvokerBallSpawner(Ball script)
    {
        invokerBall = script;
        foreach(UnityAction action in listenersBall)
        {
            invokerBall.AddListener(action);
        }
    }

    public static void RemoveInvokerBallSpawner()
    {
        invokerBall = null;
    }


    public static void AddListenerAddPoint(UnityAction<int> handler)
    {
        listenerPoint = handler;

        foreach (Block blocks in invokersPoint)
        {
            blocks.AddListener(listenerPoint);
        }

    }

    public static void AddInvokerAddPoint(Block script)
    {
        invokersPoint.Add(script);

        if (listenerPoint != null)
        {
            script.AddListener(listenerPoint);
        }

    }

    public static void AddListenerGameOver(UnityAction<int> handler)
    {
        listenerGameOver = handler;

        if(invokerGameOver != null)
        {
            invokerGameOver.AddListener(listenerGameOver);
        }

    }

    public static void AddInvokerGameOver(LevelBuilder script)
    {
        invokerGameOver = script;

        if (listenerGameOver != null)
        {
            invokerGameOver.AddListener(listenerGameOver);
        }

    }

}

