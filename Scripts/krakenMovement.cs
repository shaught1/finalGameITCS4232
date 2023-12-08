using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krakenMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    public Transform player;
    public float chaseRange = 2f;
    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing == true){
            Chase();
        }
        else{
            Patrol();
        }
    }
    void Patrol(){
        if (waypoints.Length == 0){
            return;
        }

        Transform currentWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < chaseRange){
            isChasing = true;
        }
    }
    void Chase(){
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > chaseRange){
            isChasing = false;
        }
    }
}
