using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = true;
            CheckBothPlates();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isActivated = false;
            CheckBothPlates();
        }
    }

    void CheckBothPlates()
    {
        // Assuming you have another script to manage the door
        PuzzleManager.Instance.CheckPressurePlates();
    }
}

