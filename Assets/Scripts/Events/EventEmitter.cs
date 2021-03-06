﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEmitter : MonoBehaviour{
    public delegate void EventCallback(Object[] parameters);

    private Dictionary<string, List<EventCallback>> events;

    private void Awake(){
        events = new Dictionary<string, List<EventCallback>>();
    }

    public void on(string eventname, EventCallback eventcallback) {
        if (!events.ContainsKey(eventname)) events.Add(eventname, new List<EventCallback>());
        events[eventname].Add(eventcallback);
    }

    public void invoke(string eventname, Object[] parameters) {
        if (!events.ContainsKey(eventname)) return;
        foreach (EventCallback e in events[eventname]) {
            e(parameters);
        }
    }

}
