using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public int optimalSolution;
    public int trysToHelpPlayer;
    public int counter;
    public GameObject doorOpen;
    public GameObject doorClosed;

    // Start is called before the first frame update
    public void OpenDoor()
    {
        doorClosed.SetActive(false);
        doorOpen.SetActive(true);
    }
}
