using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class Button_Behaviour : MonoBehaviour
{
    private Player_Controls Player_Action_Controls;
    public TextMeshPro Button_Text;
    private bool Player_In_Range = false;

    private void Awake()
    {
        Player_Action_Controls = new Player_Controls();
    }

    private void Start()
    {
        Button_Text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Player_In_Range && Player_Action_Controls.Gameplay.Interact.triggered)
        {
            Button_Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Debug.Log("Player has entered!");
            Player_In_Range = true;
            Button_Text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Debug.Log("Player has exited!");
            Player_In_Range = false;
            Button_Text.gameObject.SetActive(false);
        }
    }

    public void Button_Interact()
    {
        Debug.Log("I am a Button!\n You pushed Me!");
    }
}
