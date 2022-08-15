using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnToStart : MonoBehaviour
{
    public Transform startPoint;
    Transform player,bot;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Player" && collision.gameObject.transform.tag != "Bot")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Fall");
            player = collision.gameObject.transform;
            player.GetComponent<PlayerController>().speed = 0;
            Invoke("Teleport", 2f);
        }
        /*else if (collision.gameObject.transform.tag == "Bot" && collision.gameObject.transform.tag != "Player")
        {
            Invoke("TeleportBot", 2f);
            collision.gameObject.GetComponent<Animator>().SetTrigger("Fall");
            bot = collision.gameObject.transform;
            bot.GetComponent<NavMeshAgent>().speed = 0;
            bot.GetComponent<Collider>().enabled = false;
            
        }*/
    }
    void Teleport()
    {
        player.position = startPoint.position;
        player.GetComponent<Animator>().SetTrigger("Run");
        player.GetComponent<PlayerController>().speed = 0.1875f;
    }
    void TeleportBot()
    {
        bot.GetComponent<NavMeshAgent>().Warp(startPoint.position); 
        bot.GetComponent<Animator>().SetTrigger("Run");
        bot.GetComponent<NavMeshAgent>().speed = 0.1875f;
        bot.GetComponent<Collider>().enabled = true;
    }
}
