using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTimer : MonoBehaviour
{
    public float maxDistance = 20f;
    public GameStarter gameStarter;
    public GameObject[] finishLinePoints;
    public GameObject finishDetectionPoint;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Triggered");
        // Check if the car has collided with a trigger collider
        if (collision.gameObject.CompareTag("finishLine"))
        {
            Debug.Log("Triggered1");
            // if(other.CompareTag("finishLine"))
            // {
            //     // If the car has collided with the finish line, stop the timer
            // }
            gameStarter.FinishedLap();
        }
    }
    void Update()
    {
        foreach (GameObject otherObject in finishLinePoints)
        {
            // Calculate the distance between the single object and the current other object
            float distance = Vector3.Distance(finishDetectionPoint.transform.position, otherObject.transform.position);
            // Debug.Log(distance);
            // Check if the distance is less than the maximum distance threshold
            if (distance < maxDistance)
            {
                Debug.Log("here");
                gameStarter.FinishedLap();
                break; // Exit the loop if the condition is met for efficiency
            }
        }
    }
}
