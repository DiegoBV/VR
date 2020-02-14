using System;
using System.Collections.Generic;

/// <summary>
/// EventManager class. Stores every event. Arrange them in a Dictionary (quick access). 
/// Singleton, so it can be accessed from every script.Receives a trigger message and forwards it
/// to every listener.Its used to trigger actions between gameObjects.
/// </summary>
public class EventManager
{
    private static EventManager instance = null;
    private Dictionary<string, Action> eventDictionary;
    private EventManager() { eventDictionary = new Dictionary<string, Action>(); }

    public static EventManager GetInstance() //singleton pattern
    {
        if (instance == null)
        {
            instance = new EventManager();
        }

        return instance;
    }

    /// <summary>
    /// Adds a listener for the given event 'key'
    /// </summary>
    /// <param name="key">Event</param>
    /// <param name="listener">Listener</param>
    public void AddListener(string key, Action listener) //this is supposed to be called at enable of every script who wants to listen
    {
        Action thisEvent;

        if (GetInstance().eventDictionary.TryGetValue(key, out thisEvent)) //if the value is inside
        {
            thisEvent += listener;
            GetInstance().eventDictionary[key] = thisEvent;
        }
        else //if it is not, add it
        {
            thisEvent += listener;
            GetInstance().eventDictionary.Add(key, thisEvent);
        }
    }

    /// <summary>
    /// Removes a listener for the given event 'key'
    /// </summary>
    /// <param name="key">Event</param>
    /// <param name="listener">Listener</param>
    public void RemoveListener(string key, Action listener) //called in "OnDisable"
    {
        Action thisEvent;

        if (GetInstance().eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent -= listener;
            GetInstance().eventDictionary[key] = thisEvent;
            if (thisEvent == null)
                GetInstance().eventDictionary.Remove(key);
        }
    }

    /// <summary>
    /// Invokes every registered Action for the event 'key'
    /// </summary>
    /// <param name="key">Event to trigger</param>
    public void TriggerEvent(string key)
    {
        Action thisEvent;

        if (GetInstance().eventDictionary.TryGetValue(key, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}