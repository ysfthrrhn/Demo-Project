using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    NavMeshAgent navMesh;
    public Transform destination;
    public Transform startPoint;

    void Start()
    {
        navMesh = transform.GetComponent<NavMeshAgent>();
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Run");
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(destination.position);
        
        if(transform.position.z >= 4.65f)
        {
            Invoke("ShutDown", 1.5f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Respawn")
        {
            Invoke("TeleportBot", 2f);
            transform.GetComponent<Animator>().SetTrigger("Fall");
            
            navMesh.speed = 0;
            transform.GetComponent<Collider>().enabled = false;

        }
    }
    void TeleportBot()
    {
        navMesh.Warp(startPoint.position);
        transform.GetComponent<Animator>().SetTrigger("Run");
        navMesh.speed = 0.1875f;
        transform.GetComponent<Collider>().enabled = true;
    }
    void ShutDown()
    {
        transform.GetComponent<Collider>().enabled = false;
        transform.GetComponent<Animator>().SetTrigger("Idle");
        navMesh.speed = 0;
    }
}
