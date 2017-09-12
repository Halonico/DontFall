using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private State state;
    /*
     * This constructor create the platform with the moving state
     */
    public Platform()
    {
        state = new MovingState(this);
    }
    /*
     * This method call the start method of the state 
     */
    public void Start()
    {
        state.Start();
    }
    /*
     * This method call the update method of the state 
     */
    void FixedUpdate()
    {
        state.Update();
    }
    /*
    * This method change the state of the platform
    */
    public void nextState()
    {
       state= state.nextState();
    }
    /*
     *This method destroy the platform 
     */
    public void kill()
    {
        DestroyImmediate(this.gameObject);
    }
}