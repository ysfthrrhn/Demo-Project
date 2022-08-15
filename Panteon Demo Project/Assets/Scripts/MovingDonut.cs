using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDonut : MonoBehaviour
{
    public Transform firstPoint, secondPoint;
    public float speed = 0.25f,tempSpeed = 0.25f;
    public bool control = false;
    bool secondControl = true;

    private void Update()
    {
        HandleObstacleMovement();
        CheckLimits();
    }

    void HandleObstacleMovement()
    {
        if (control)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (!control)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    void CheckLimits()
    {
        if (secondControl)
        {
            if (transform.position.x <= firstPoint.position.x)
            {
                secondControl = false;
                transform.position = firstPoint.position;
                speed = 0;
                Invoke("ChangeDirection", 2);
            }
            if (transform.position.x >= secondPoint.position.x)
            {
                secondControl = false;
                transform.position = secondPoint.position;
                speed = 0;
                Invoke("ChangeDirection", 2);
            }
        }
    }

    void ChangeDirection()
    {
        control =! control;
        speed = tempSpeed;
        secondControl = true;
    }

}
