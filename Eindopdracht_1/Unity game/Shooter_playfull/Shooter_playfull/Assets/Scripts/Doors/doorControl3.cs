using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl3 : MonoBehaviour {

    public float speed;
    public float angle;
    public Vector3 direction;
        
       // Use this for initialization
	void Start () {
        angle = transform.localEulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Round(transform.localEulerAngles.y) != angle)
            //rotate door
            transform.Rotate(direction * speed);
        {

            if (Input.GetKeyDown(KeyCode.O))
            {
                angle = 270;
                direction = Vector3.up;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                angle = 0;
                direction = Vector3.up;

            }
        }
		
	}
}
