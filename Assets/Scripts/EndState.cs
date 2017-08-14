using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    Vector3 destinationPos;
    public EndState(Platform platform) : base(platform)
    {
        destinationPos = new Vector3(base.getPlatform().transform.position.x, -20f, base.getPlatform().transform.position.z);
    }
    public override State nextState()
    {
        return this;
    }

    public override void Update()
    {
        if (getPlatform().transform.position == destinationPos)
        {
            base.getPlatform().kill();
        }
        else
        {
            getPlatform().transform.position = Vector3.MoveTowards(getPlatform().transform.position, destinationPos, 0.2F);
        } 
    }
    public override void Start()
    {
        

    }
}