using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]  // allow for in-editor creation of scriptable object
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    /// <summary>
    /// Raises the game event
    /// </summary>
    public void Raise(Component sender, object data)
    {
        // Loop through all of the listeners and invoke their responses
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender, data);
        }
    }

    /// <summary>
    /// Registers a listener to the game event
    /// </summary>
    /// <param name="listener"></param>
    public void RegisterListener(GameEventListener listener)
    {
        // Check if the list already contains the listener
        if (!listeners.Contains(listener))
        {
            // If it doesn't, add the listener to the list
            listeners.Add(listener);
        }
    }

    /// <summary>
    /// Unregisters a listener from the game event
    /// </summary>
    /// <param name="listener"></param>
    public void UnregisterListener(GameEventListener listener)
    {
        // Check if the list contains the listener
        if (listeners.Contains(listener))
        {
            // If it does, remove the listener from the list
            listeners.Remove(listener);
        }
    }
}
