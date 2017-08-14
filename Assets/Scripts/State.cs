using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
    private Platform platform;
    public State(Platform platform)
    {
        this.platform = platform;
    }
    public abstract void Update();
    public abstract void Start();
    public abstract State nextState();
    public Platform getPlatform()
    {
        return platform;
    }
}
