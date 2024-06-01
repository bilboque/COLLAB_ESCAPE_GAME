using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public PressurePlate plate1;
    public PressurePlate plate2;
    public GameObject doorClosed;
    public GameObject doorOpened;

    void Awake()
    {
        Instance = this;
    }

    public void CheckPressurePlates()
    {
        if (plate1.isActivated && plate2.isActivated)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        // open a door prop on the map maybe
        doorClosed.SetActive(false);
        doorOpened.SetActive(true);
    }

}
