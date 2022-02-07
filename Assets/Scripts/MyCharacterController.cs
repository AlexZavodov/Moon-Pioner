using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float gravityForce = 20;

    private float currentAttractionCharacter = 0;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = currentAttractionCharacter;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (characterController.isGrounded)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }

    private void Update()
    {
        GravityHandling();
    }

    private void GravityHandling()
    {
        if (!characterController.isGrounded)
        {
            currentAttractionCharacter -= gravityForce * Time.deltaTime;
        }
        else
        {
            currentAttractionCharacter = 0;
        }
    }
}
