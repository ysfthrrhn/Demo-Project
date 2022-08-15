using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool direction = false;
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        if (direction)
        {
            transform.Rotate(0, Time.deltaTime * 60, 0);
        }
        else if (!direction)
        {
            transform.Rotate(0, -Time.deltaTime * 60, 0);
        }
    }
}
