using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private State state;
    public Platform()
    {
        state = new MovingState(this);
    }
    public void Start()
    {
        state.Start();
    }
    void FixedUpdate()
    {
        state.Update();
    }
    public void nextState()
    {
       state= state.nextState();
    }
    public void kill()
    {
        DestroyImmediate(this.gameObject);
    }
}