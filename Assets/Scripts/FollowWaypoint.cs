using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    public float rotSpeed;
    public float speed;
    public float waypointThreshold = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 direction = waypoints[currentWaypoint].transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
        transform.Translate(0, 0, speed * Time.deltaTime);
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position);
        if (distanceToWaypoint < waypointThreshold)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}