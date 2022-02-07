using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : JoystickHandler
{
    [SerializeField]
    MyCharacterController characterController;

    private void Update()
    {   
        if (inputVector.x != 0 || inputVector.y != 0)
        {
            characterController.MoveCharacter   (new Vector3(inputVector.x, 0, inputVector.y));
            characterController.RotateCharacter (new Vector3(inputVector.x, 0, inputVector.y));

        }
    }
}
