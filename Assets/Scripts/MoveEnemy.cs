using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Transform> waypoints;
    private int currentWaypoint = 0;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(waypoints.Count > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // si no quedan más paths pendientes y la distancia que flata por recorrer es <= que la distancia
        // a la que se detiene mueve el objeto
        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //siguiente waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
            //añadir como destino
            agent.SetDestination(waypoints[currentWaypoint].position); 
        }
    }
}
