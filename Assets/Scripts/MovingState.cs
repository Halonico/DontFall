using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    public static float speed=0.05f;
    private Vector3 firstPos, secondPos,destinationPos;
    public MovingState(Platform platform) : base(platform)
    {}
    public override void Start()
    {
        firstPos = new Vector3(base.getPlatform().transform.position.x, 0, -5);
        secondPos = new Vector3(base.getPlatform().transform.position.x, 0, 5);
        speed += 0.01f;
        destinationPos = firstPos;
    }
    public override void Update()
    {
        if (getPlatform().transform.position == firstPos)
        {
            destinationPos = secondPos;
        }
        else if (getPlatform().transform.position == secondPos)
        {
            destinationPos = firstPos;
        }
       getPlatform().transform.position= Vector3.MoveTowards(base.getPlatform().transform.position, destinationPos, speed);
    }
    public override State nextState()
    {
        return new IdleState(this.getPlatform());
    }
}
