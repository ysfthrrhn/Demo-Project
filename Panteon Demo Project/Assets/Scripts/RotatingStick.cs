using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {       
        if(collision.transform.tag == "Player")
        {
            //collision.rigidbody.AddForce(transform.forward * 50); 
            ContactPoint contact = collision.contacts[0]; //To apply force from right direction
            Vector3 direction = collision.transform.position - contact.point;
            collision.rigidbody.AddForceAtPosition(direction.normalized * 100, contact.point);
        }
        if (collision.transform.tag == "Bot")
        {
            //collision.rigidbody.AddForce(transform.forward * 50); 
            ContactPoint contact = collision.contacts[0]; //To apply force from right direction
            Vector3 direction = collision.transform.position - contact.point;
            collision.rigidbody.AddForceAtPosition(direction.normalized * 150, contact.point);
        }
    }
}
