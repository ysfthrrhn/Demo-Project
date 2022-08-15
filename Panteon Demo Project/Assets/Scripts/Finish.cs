using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finish : MonoBehaviour
{
    Transform player;
    public PaintingWall wall;
    public CameraController controller;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            player = collision.transform;
            Invoke("PlayerAtFinish",1.5f);
            wall.enabled = true;
            
        }
    }
    void PlayerAtFinish()
    {
        player.GetComponent<PlayerController>().speed = 0;
        player.transform.GetComponent<Animator>().SetTrigger("Idle");
        controller.finishControl = true;
    }
}
