using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform player;
    public float speed=0.1875f;
    private Vector3 newPosition;
    private float dragCurrentPosition;
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Run");
        player = GetComponent<Transform>();
        newPosition = transform.position;
        dragCurrentPosition = Input.mousePosition.x;
        newPosition = new Vector3(Input.mousePosition.x - dragCurrentPosition, 0, 0);
    }
    void Update()
    {
        HandleMovement();
        HandleMousetInput();        
    }
    void HandleMousetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragCurrentPosition = Input.mousePosition.x;  
        }
        else if (Input.GetMouseButton(0))
        { 
            newPosition = new Vector3(Input.mousePosition.x - dragCurrentPosition,0,0);
            dragCurrentPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            newPosition.x = 0;
        }

    }
    void HandleMovement()
    {
        player.position += player.forward * speed * Time.deltaTime; //To move forward  
        if(player.position.x < - 0.213 || player.position.x > 0.213)
        {
            player.position += newPosition * speed / 3 * Time.deltaTime;
        }
        else
        {
            player.position += newPosition * speed * Time.deltaTime;
        }    
    }
}
