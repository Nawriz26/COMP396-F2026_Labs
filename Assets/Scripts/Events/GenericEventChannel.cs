using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannel<T> : ScriptableObject
{
    public event UnityAction<T> OnEventRaised;
    public event UnityAction<T, GameObjectEventType> OnEventTypeRaised;

    public void RaiseEvent(T value)
    {
        OnEventRaised?.Invoke(value);
    }

    public void RaiseEvent(T value, GameObjectEventType eventType)
    {
        OnEventTypeRaised?.Invoke(value, eventType);
    }
}