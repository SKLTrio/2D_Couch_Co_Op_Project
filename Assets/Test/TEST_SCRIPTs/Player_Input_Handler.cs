using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;

public class Player_Input_Handler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Player_Movement_Script Player_Movement_Script; // Assuming you've updated your Mover script as per the previous response.

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var Player_Movement = FindObjectsOfType<Player_Movement_Script>();
        var index = playerInput.playerIndex;
        Player_Movement_Script = Player_Movement.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }

    public void OnMove(CallbackContext context)
    {
        if (Player_Movement_Script != null)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            Player_Movement_Script.SetInputVector(moveInput);
        }
    }

    public void OnJump(CallbackContext context)
    {
        if (Player_Movement_Script != null)
        {
            Player_Movement_Script.Jump();
        }
    }
}
