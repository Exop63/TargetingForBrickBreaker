using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public GameEventsObject eventsObject;
    public UnityEvent shot;
    public UnityEvent endDrag;

    void OnEnable()
    {
        this.eventsObject.ShotRegister(this);
    }
    void OnDisable()
    {
        this.eventsObject.ShotUnRegister(this);
    }



}
