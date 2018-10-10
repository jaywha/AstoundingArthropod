using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vMovingMesh : MonoBehaviour
{
    public float speed = 1.0f;
    private float startTime = 0.0f;
    private float journeyLength = 0.0f;

    public Transform startMarker;
    public Transform endMarker;

    private Transform mark1, mark2;

    // Use this for initialization
    void Start()
    {
        startTime = Time.fixedTime;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        mark1 = startMarker;
        mark2 = endMarker;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.fixedTime - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(mark1.position, mark2.position, fracJourney);

        Debug.Log("Fraction of the Journey --> " + fracJourney);

        if(fracJourney >= 1.0f)
        {
            startTime = Time.fixedTime;
            mark1 = (mark1 == startMarker ? endMarker : startMarker);
            mark2 = (mark2 == endMarker ? startMarker : endMarker);
        }
    }
}
