using System.Collections;
using System.Collections.Generic;
using Unity.Multiplayer.Tools.NetStatsMonitor;
using UnityEngine;

public class DifficultyTrigger : MonoBehaviour
{
    public DifficultyManager difficultyManager;
    private void OnTriggerEnter2D()
    {
        difficultyManager.counter += 1;
        Debug.Log(difficultyManager.counter);
        if(difficultyManager.counter == difficultyManager.trysToHelpPlayer)
        {
            difficultyManager.OpenDoor();
        }
    }
}
