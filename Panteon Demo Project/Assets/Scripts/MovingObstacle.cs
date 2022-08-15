using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform firstPoint, secondPoint;
    public float speed=0.25f;
    public bool control = false;

    // Update is called once per frame
    void Update()
    {
        HandleObstacleMovement();
        CheckLimits();
    }
    void HandleObstacleMovement()
    {
        if (control)
        {
            transform.position += transform.right * speed *Time.deltaTime;
        }
        if (!control)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
    void CheckLimits()
    {
        if(transform.localPosition.x <= firstPoint.localPosition.x)
        {
            control = true;
        }
        if(transform.position.x >= secondPoint.position.x)
        {
            control = false;
        }
    }
}
