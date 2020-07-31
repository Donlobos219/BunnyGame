using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Taller;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Action updateCallback;
    
    private void Awake()
    {
        
         AddUpdateCallback(EventTouch.ExternalUpdate);

    }
    public  void AddUpdateCallback(Action updateMethod)
    {
       updateCallback += updateMethod;
    }

   
    public void NotifyPlayerDead()
    {
        print("player is dead");

    }

    private void Update()
    {
        if(updateCallback!=null)
        updateCallback();
    }

   
}


public static class EventManager
{
   // public static Dictionary<string, Action<object>> eventList;
    public static Dictionary<string, Delegate> delegateList;

     
    public static void AddEvent(string eventName, Delegate Param)
    {
        if (delegateList == null)
        {
            //Debug.LogError("eventList==null");
            delegateList = new Dictionary<string, Delegate>();

        }


        delegateList.Add(eventName, Param);

    }
     public static void AddEvent<T>(string eventName, Action<T> Param)
    {
        if (delegateList == null)
        {
            //Debug.LogError("eventList==null");
            delegateList = new Dictionary<string, Delegate>();

        }


        delegateList.Add(eventName, Param); 

    } 
    /*public static void AddEvent<T>(string eventName, Action<T> Param)
    {
        if(eventList==null)
        {
            //Debug.LogError("eventList==null");
            eventList = new Dictionary<string, Action<object>>();

        }

         
        eventList.Add(eventName, o => Param((T)o));

    }
    public static void TriggerEvent<T>(string eventName, T parameter1)
    {

        if (eventList.ContainsKey(eventName))
        {
            Action<object> eventTocall;

            if (eventList.TryGetValue(eventName, out eventTocall))
            {
                if (eventTocall == null) return;
                eventTocall(parameter1);

            }
        }

    }*/
    public static void TriggerEvent<T>(string eventName, T parameter1)
    {
        if(delegateList.ContainsKey(eventName))
        {
            Delegate eventTocall;

            if(delegateList.TryGetValue(eventName,out eventTocall))
            {
                if (eventTocall == null) return;

                eventTocall?.DynamicInvoke(parameter1);

            }
        }

    }


}
