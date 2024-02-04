using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

public class GameEventListener : MonoBehaviour
{
    #region FIELDS

    public GameEvent gameEvent;
    public CustomGameEvent response;

    #endregion

    /// <summary>
    /// Register to the gamne event during OnEnable()
    /// </summary>
    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    /// <summary>
    /// Unregister to the game event during OnDisable()
    /// </summary>
    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    /// <summary>
    /// Invokes the response when the game event is raised
    /// </summary>
    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }
}



