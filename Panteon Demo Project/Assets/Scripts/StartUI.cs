using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public PlayerController player;
    public OpponentController[] opponent;
    public CameraController cam;
    public GameObject raceUI;
    public void StartGame()
    {
        Invoke("CloseMenu", 0.1f);
        cam.enabled = true;
        Invoke("ActivateCharacters", 3f);
    }
    void CloseMenu()
    {
        transform.gameObject.SetActive(false);
    }
    void ActivateCharacters()
    {
        raceUI.SetActive(true);
        player.enabled = true;
        for(int i = 0; i < opponent.Length; i++)
        {
            opponent[i].enabled = true;
        }
    }
}
