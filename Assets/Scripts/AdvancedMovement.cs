using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{
    PlayerMovement basicMovementScript;
    public float speedBoost = 12f;
   
    void Start()
    {
        basicMovementScript = GetComponent <PlayerMovement>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
            basicMovementScript.speed += speedBoost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            basicMovementScript.speed -= speedBoost;
    }
}
