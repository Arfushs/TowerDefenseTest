using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypointList;

    public Vector3 GetStartPosition()
    {
        return _waypointList[0].position;
    }

    public List<Transform> GetTransformArray()
    {
        return _waypointList;
    }
}
