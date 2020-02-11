using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours
{
    public static Vector3 Follow(Vector3 origin, Vector3 destination, float speed)
    {
        Vector3 dir = new Vector3(destination.x - origin.x, destination.y - origin.y, destination.z - origin.z); //simple vector calc dest - src (we dont want to follow the y coord)
        dir.Normalize();
        Vector3 nPosition = origin;

        //move towards dest
        nPosition.x += dir.x * Time.deltaTime * speed;
        nPosition.y += dir.y * Time.deltaTime * speed;

        return nPosition;
    }
}
