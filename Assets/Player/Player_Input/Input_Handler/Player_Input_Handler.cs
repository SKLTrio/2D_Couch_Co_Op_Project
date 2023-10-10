using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.InputSystem;

public class Player_Input_Handler : MonoBehaviour
{
    private PlayerInput Player_Input;
    private Button_Behaviour Button_Behaviour_Script;
    private Player_Movement_Script Player_Movement_Script; // Assuming you've updated your Mover script as per the previous response.

    private void Awake()
    {
        Player_Input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        // You can keep this part for later initialization if needed.
        // For now, just get references to the other components.
        Button_Behaviour_Script = GetComponent<Button_Behaviour>();
        var Player_Movement = FindObjectsOfType<Player_Movement_Script>();
        var index = Player_Input ? Player_Input.playerIndex : -1;
        Player_Movement_Script = Player_Movement.FirstOrDefault(m => m.Get_Player_Index() == index);
    }



    public void OnMove(CallbackContext Context)
    {
        if (Player_Movement_Script != null)
        {
            Vector2 moveInput = Context.ReadValue<Vector2>();
            Player_Movement_Script.Set_Input_Vector(moveInput);
        }
    }

    public void OnJump(CallbackContext Context)
    {
        if (Player_Movement_Script != null)
        {
            Player_Movement_Script.Jump();
        }
    }

    public void OnInteract(CallbackContext Context)
    {
        if (Player_Movement_Script != null)
        {
            Button_Behaviour_Script.Button_Interact();
        }
    }
}
