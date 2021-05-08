using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    CharacterController characterCollider;

    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
            characterCollider.height = 2.0f;
        else
            characterCollider.height = 3.5f;
    }
}
