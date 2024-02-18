using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [field: SerializeField] public Vector3 TargetDestination { get; private set; }

    public int currentDestinationIndex;

    [field: SerializeField] public List<Vector3> Destinations = new List<Vector3>();
    [field: SerializeField] public float LookingTime { get; private set; }

    [HideInInspector] public float currentLookingTime;

    [SerializeField] private float distanceBuffer;

    private void Start()
    {
        currentLookingTime = LookingTime;
    }

    /// <summary>
    /// Decrease looking timer value
    /// </summary>
    public void LookAround()
    {
        currentLookingTime -= Time.deltaTime;
    }

    /// <summary>
    /// Check if the looking timer has reached is limit
    /// </summary>
    /// <returns></returns>
    public bool IsDoneLooking()
    {
        return currentLookingTime <= 0;
    }

    /// <summary>
    /// Set next destination
    /// </summary>
    public void SetNextDestination()
    {
        currentLookingTime = LookingTime;
        currentDestinationIndex = (currentDestinationIndex + 1) % Destinations.Count;
        TargetDestination = Destinations[currentDestinationIndex];
    }

    /// <summary>
    /// Check if the object has reached is destination
    /// </summary>
    /// <returns></returns>
    public bool DestinationReached()
    {

        float distance = Vector3.Distance(transform.position, TargetDestination);
        return distance < distanceBuffer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < Destinations.Count; i++)
        {
            // Draw a sphere at each navigaton points
            Gizmos.DrawWireSphere(Destinations[i], 0.5f);
        }
    }
}
