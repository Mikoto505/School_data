using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour {

    public Transform player;
    public LayerMask doorMask;
    public Transform currentDoor;
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if(Physics.Raycast(player.position, player.forward, out hit, doorMask))
        {
            if (hit.transform.CompareTag("Door"))
            {
                currentDoor = hit.transform;
            } else
            {
                currentDoor = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if(currentDoor != null)
            {
                currentDoor.GetComponentInParent<DoorScript>().interactWithDoor();
            }
        }
	}
}
