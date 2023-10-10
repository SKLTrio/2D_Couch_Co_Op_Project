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

    [SerializeField] public SpriteRenderer Button_Sprite;
    [SerializeField] public Sprite Button_Pushed_Sprite;
    [SerializeField] public GameObject Wall;

    private bool Player_In_Range = false;

    private void Awake()
    {
        Player_Action_Controls = new Player_Controls();
    }

    private void Start()
    {
        Button_Text.gameObject.SetActive(false);
        Wall.SetActive(true);
    }

    private void OnEnable()
    {
        Player_Action_Controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        Player_Action_Controls.Gameplay.Enable();
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
            Player_In_Range = true;
            Button_Text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Player_In_Range = false;
            Button_Text.gameObject.SetActive(false);
        }
    }

    public void Button_Interact()
    {
        if (Button_Sprite != null)
        {
            Button_Sprite.sprite = Button_Pushed_Sprite;
            Wall.SetActive(false);
        }
    }
}
