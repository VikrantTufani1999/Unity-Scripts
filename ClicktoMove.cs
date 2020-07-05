// _Author_ : Vikrant Kumar Tufani
// Date : 5th July 2020

// Logic Source code for Click to Move Function in Unity 5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicktoMove : MonoBehaviour
{
    private float speed = 4;

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Update()
    {
            if (Input.GetMouseButton(0))			//Detect Mouseclick and set Target Position
            {
                SetTargetPosition();
            }

            if (isMoving)							// Start moving the Object only after the target position is set
            {
                Move();
            }
    }

    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);		//fetch mouse position
        targetPosition.z = transform.position.z;										

        isMoving = true;
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);				// control rotation towards target point
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 	// Control Movement towards target point 
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
