using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    public delegate void Handler(Event e);
}

public class EventManager
{
    /*
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }
    */
    private Dictionary<System.Type, Event.Handler> registeredHandlers
        = new Dictionary<System.Type, Event.Handler>();
    private List<Event> queuedEvents = new List<Event>();

    public void QueueEvent(Event e)
    {
        queuedEvents.Insert(0, e);
    }

    public void ProcessQueuedEvents()
    {
        for (int i = queuedEvents.Count - 1; i >= 0; --i)
        {
            Fire(queuedEvents[i]);
            queuedEvents.RemoveAt(i);
        }
    }

    public void Register<T>(Event.Handler handler) where T : Event
    {
        System.Type t = typeof(T);
        if (registeredHandlers.ContainsKey(t))
        {
            registeredHandlers[t] += handler;
        }
        else
        {
            registeredHandlers[t] = handler;
        }
    }

    public void Unregister<T>(Event.Handler handler) where T : Event
    {
        System.Type type = typeof(Event);
        Event.Handler handlers;
        if (registeredHandlers.TryGetValue(type, out handlers))
        {
            handlers -= handler;
            if (handler == null)
            {
                registeredHandlers.Remove(type);
            }
            else
            {
                registeredHandlers[type] = handlers;
            }
        }
    }

    public void Fire(Event e)
    {
        System.Type type = e.GetType();
        Event.Handler handlers;
        if (registeredHandlers.TryGetValue(type, out handlers))
        {
            handlers(e);
        }
    }
}