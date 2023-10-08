using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine;


public class Player_Input_Manager : MonoBehaviour
{
    private Player_Movement_Old Player_Movement_Script;
    private PlayerInput Player_Input;

    private void Awake()
    {
        Player_Input = GetComponent<PlayerInput>();
        var Player_Movement = FindObjectsOfType<Player_Movement_Old>();
        var Player_Index = Player_Input.playerIndex;
        //Player_Movement_Script = GetComponent<Player_Movement>();
        Player_Movement_Script = Player_Movement.FirstOrDefault(m => m.Grab_Player_Index() == Player_Index);
    }


}
