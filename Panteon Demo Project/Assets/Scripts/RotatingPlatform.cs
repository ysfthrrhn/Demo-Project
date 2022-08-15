using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotatingPlatform : MonoBehaviour
{
    public bool direction = false;
    public float speed = 0.1875f;
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        if (direction)
        {
            transform.Rotate(0, 0, Time.deltaTime * 20);
        }
        else if (!direction)
        {
            transform.Rotate(0, 0, -Time.deltaTime * 20);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (direction)
        {
            if (collision.transform.tag == "Player")
            {
                collision.transform.position += -collision.transform.right * speed * Time.deltaTime;
            }
            else if (collision.transform.tag == "Bot")
            {
                //To manipulate navMesh Agent
                collision.gameObject.GetComponent<NavMeshAgent>().Warp(collision.transform.position - collision.transform.right * speed * Time.deltaTime + collision.transform.forward * speed * 1.25f * Time.deltaTime);
            }
        }
        else if (!direction)
        {
            if (collision.transform.tag == "Player")
            {
                collision.transform.position += collision.transform.right * speed * Time.deltaTime;
            }
            else if (collision.transform.tag == "Bot")
            {
                collision.gameObject.GetComponent<NavMeshAgent>().Warp(collision.transform.position + collision.transform.right * speed * Time.deltaTime + collision.transform.forward * speed * 1.25f * Time.deltaTime);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (direction)
        {
            if (collision.transform.tag == "Player")
            {
                collision.transform.position += -collision.transform.right * speed * Time.deltaTime;
            }
            else if (collision.transform.tag == "Bot")
            {
                //To manipulate navMesh Agent
                collision.gameObject.GetComponent<NavMeshAgent>().Warp(collision.transform.position - collision.transform.right * speed * Time.deltaTime + collision.transform.forward * speed * Time.deltaTime);
            }
        }
        else if (!direction)
        {
            if (collision.transform.tag == "Player")
            {
                collision.transform.position += collision.transform.right * speed * Time.deltaTime;
            }
            else if (collision.transform.tag == "Bot")
            {
                collision.gameObject.GetComponent<NavMeshAgent>().Warp(collision.transform.position + collision.transform.right * speed * Time.deltaTime + collision.transform.forward * speed * Time.deltaTime);
            }
        }

    }

}
