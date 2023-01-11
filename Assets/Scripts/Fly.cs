using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 10.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private bool isFlying = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isFlying = !isFlying;
        }

        if (isFlying)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}

