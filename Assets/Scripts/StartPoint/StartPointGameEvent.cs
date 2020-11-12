using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartPointGameEvent : MonoBehaviour
{
    public StartPointData Event;
    public UnityEvent OnChangin;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised()
    { OnChangin.Invoke(); }
}
