using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public GameObject closedDoor;
    public GameObject openDoor;
    private bool isOpen = false;

    public override void Interact()
    {
        isOpen = !isOpen;
        closedDoor.SetActive(!isOpen);
        openDoor.SetActive(isOpen);
        Debug.Log("Door " + (isOpen ? "Opened" : "Closed"));
    }
}
