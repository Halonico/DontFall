using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Platform platform) : base(platform)
    {}
    public override State nextState()
    {
        return new EndState(base.getPlatform());
    }

    public override void Update()
    {
    }
    public override void Start()
    {
       
    }
}