using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform mainCameraPosition;
    public Transform lastPosition;
    bool control = false;
    public bool finishControl = false;
    private void Start()
    {
        Invoke("ChangeControl", 3f);
    }
    void Update()
    {
        if (control)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, player.position.z), 5 * Time.deltaTime);
        }
        if (finishControl)
        {
            control = false;
            
            lookAtWall();
        }
        
        
        RepositionCamera();
    }
    void RepositionCamera()
    {
        
        transform.GetChild(0).position = Vector3.Lerp(transform.GetChild(0).position,mainCameraPosition.position, 0.5f * Time.deltaTime);
        transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation,mainCameraPosition.rotation, 1 * Time.deltaTime);
    }
    void ChangeControl()
    {
        control = !control;
    }
    void lookAtWall()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0,0.5f,5), 0.5f * Time.deltaTime);
        transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, lastPosition.rotation, 2 * Time.deltaTime);
    }
}
