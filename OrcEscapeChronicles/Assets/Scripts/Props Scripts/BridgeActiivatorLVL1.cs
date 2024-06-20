using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActiivatorLVL1 : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject bridge; 
   public GameObject bridgeWalls; 
   public GameObject openBridge;
   public GameObject glow;
   public GameObject TP;

   private bool isOpen = false;

   void OnTriggerEnter2D(Collider2D other) 
   {
    isOpen = true;
    bridge.SetActive(isOpen);
    bridgeWalls.SetActive(isOpen);
    openBridge.SetActive(!isOpen);
    glow.SetActive(isOpen);
    TP.SetActive(!isOpen);
   }
   
   void OnTriggerExit2D(Collider2D other) 
   {
    isOpen = false;
    bridge.SetActive(isOpen);
    bridgeWalls.SetActive(isOpen);
    openBridge.SetActive(!isOpen);
    glow.SetActive(isOpen);
    TP.SetActive(!isOpen);
   }
}
