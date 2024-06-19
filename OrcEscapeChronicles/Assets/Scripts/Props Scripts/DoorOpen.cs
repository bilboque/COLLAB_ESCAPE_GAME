using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject Open;
    public GameObject Closed;
    private bool isOpen = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        isOpen = true;
        Open.SetActive(isOpen);
        Closed.SetActive(!isOpen);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOpen = false;
        Open.SetActive(isOpen);
        Closed.SetActive(!isOpen);
    }

}
