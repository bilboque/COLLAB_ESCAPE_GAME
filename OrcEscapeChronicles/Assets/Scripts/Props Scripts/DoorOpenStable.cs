using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openDoor;
    private bool isOpen = false;

    void OnTriggerEnter2D()
    {
        isOpen = true;
        closedDoor.SetActive(!isOpen);
        openDoor.SetActive(isOpen);
    }
}
