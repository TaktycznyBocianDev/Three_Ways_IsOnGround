using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void IsOnGroundEvent(bool isOnGround);
    public static event IsOnGroundEvent onGroundE;

    public static void IsOnGroundFunction(bool isOnGround)
    {
        onGroundE?.Invoke(isOnGround);
    }
}
