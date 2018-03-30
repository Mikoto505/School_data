using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [Header("Settings")]
    public float speed;
    public bool doorIsOpen;
    public float openPosition;
    public float closePosition;

	// Use this for initialization
	void Start () {
        doorIsOpen = false;
	}

    public void Update()
    {
        //Debug.Log(GetComponent<Transform>().localRotation.eulerAngles.y);
        if (doorIsOpen)
        {
            if(GetComponent<Transform>().localRotation.eulerAngles.y < openPosition)
            {
                GetComponent<Transform>().Rotate(Vector3.up * speed * Time.deltaTime);
            }
        } else
        {
            if(closePosition == 0)
            {
                if (GetComponent<Transform>().localRotation.eulerAngles.y > 0)
                {
                    GetComponent<Transform>().Rotate(Vector3.down * speed * Time.deltaTime);
                }
            } else
            {
                if (GetComponent<Transform>().localRotation.eulerAngles.y > closePosition)
                {
                    GetComponent<Transform>().Rotate(Vector3.down * speed * Time.deltaTime);
                }
            }
        }
    }
	
	public void openDoor()
    {
        //if(!doorIsOpen) GetComponent<Transform>().Rotate(0, angle, 0);
        doorIsOpen = true;
    }

    public void closeDoor()
    {
        //if(doorIsOpen) GetComponent<Transform>().Rotate(0, -angle, 0);
        doorIsOpen = false;
    }

    public void interactWithDoor()
    {
        if (doorIsOpen)
        {
            closeDoor();
        } else
        {
            openDoor();
        }
    }


}
