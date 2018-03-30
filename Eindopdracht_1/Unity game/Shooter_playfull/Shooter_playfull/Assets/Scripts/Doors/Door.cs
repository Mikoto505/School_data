using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float timeLeft = 0f;
    public RaycastHit hit;
    public Transform currentdoor;
    public bool open;
    public bool isOpeningDoor;
    public Transform cam;
    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && timeLeft == 0.0f)
        {
            CheckDoor();
        }

        if (isOpeningDoor)
        {
            OpenAndCloseDoor();
        }
    }

    void CheckDoor()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 5, mask))
        {
            open = false;
            if (hit.transform.localRotation.eulerAngles.y > 45)
            {
                open = true;
            }

            isOpeningDoor = true;
            currentdoor = hit.transform;
        }
    }

    void OpenAndCloseDoor()
    {
        timeLeft += Time.deltaTime;

        if (open)
        {
            currentdoor.localRotation = Quaternion.Slerp(currentdoor.localRotation, Quaternion.Euler(0, 0, 0), timeLeft);
        }
        else
        {
            currentdoor.localRotation = Quaternion.Slerp(currentdoor.localRotation, Quaternion.Euler(0, 0, 90), timeLeft);
        }
        if (timeLeft > 1)
        {
            timeLeft = 0;
            isOpeningDoor = false;
        }
    }
}