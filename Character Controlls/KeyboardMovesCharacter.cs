using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovesCharacter : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3;
    private CharacterController characterController;
    private float gravity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get Horizontal and Vertical Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the Direction to Move based on the tranform of the Player
        Vector3 moveDirectionForward = transform.forward * verticalInput;
        Vector3 moveDirectionSide = transform.right * horizontalInput;

        //find the direction
        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        //find the distance
        Vector3 distance = direction * walkSpeed * Time.deltaTime;
        
         gravity -= 9.81f * Time.deltaTime;

        // Apply Movement to Player
        characterController.Move(new Vector3(distance.x, gravity, distance.z));

        if (characterController.isGrounded)
        {
            gravity = 0;
        }
    }
}