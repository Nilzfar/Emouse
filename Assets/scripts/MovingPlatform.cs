using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] float speed = 1f;
    int CurrentWaypointIndex = 0;

    // Update is called once per frame
    void Update()
    {    // check distance to increase index
        if (Vector3.Distance(transform.position, wayPoints[CurrentWaypointIndex].transform.position)< 0.1f)
        {
            CurrentWaypointIndex++;

            // check to go back to the first waypoint if we are at the last one.
            if (CurrentWaypointIndex >= wayPoints.Length)
            {
                CurrentWaypointIndex = 0;
            }
        }
        // MoveTowards() is a method for calculating a new position between 2 GameObject
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[CurrentWaypointIndex].transform.position, speed * Time.deltaTime);

    }
}
