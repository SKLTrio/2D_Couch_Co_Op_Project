using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    private Player_Controls Player_Action_Controls;

    private Rigidbody2D RG_Body;
    private Collider2D Player_Collider;

    private Animator Player_Animator;
    private SpriteRenderer Player_Sprite_Renderer;

    [SerializeField] private LayerMask Ground_Mask;
    [SerializeField] private float Move_Speed, Jump_Speed;
    [SerializeField] public int Life = 1;

    private void Awake()
    {
        Player_Action_Controls = new Player_Controls();
        RG_Body = GetComponent<Rigidbody2D>();
        Player_Collider = GetComponent<Collider2D>();
        Player_Animator = GetComponent<Animator>();
        Player_Sprite_Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Player_Action_Controls.Enable();
    }

    private void OnDisable()
    {
        Player_Action_Controls.Disable();
    }

    void Start()
    {
        Player_Action_Controls.Gameplay.Jump.performed += Context => Jump();
        Player_Action_Controls.Gameplay.Dash.performed += Context => Dash_Increase();
        Player_Animator.SetBool("Is_Walking", false);

    }

    private void Jump()
    {
        if (Is_Grounded())
        {
            RG_Body.AddForce(new Vector2(0, Jump_Speed), ForceMode2D.Impulse);
            Player_Animator.SetTrigger("Jump");

        }
    }

    private bool Is_Grounded()
    {
        Vector2 Top_Left_Point = transform.position;
        Top_Left_Point.x -= Player_Collider.bounds.extents.x;
        Top_Left_Point.y += Player_Collider.bounds.extents.y;

        Vector2 Bottom_Right_Point = transform.position;
        Bottom_Right_Point.x += Player_Collider.bounds.extents.x;
        Bottom_Right_Point.y -= Player_Collider.bounds.extents.y;

        return Physics2D.OverlapArea(Top_Left_Point, Bottom_Right_Point, Ground_Mask);
    }

    void Update()
    {
        Move();

        if (Life < 1)
        {
            gameObject.SetActive(false);
        }

    }

    private void Move()
    {
        // Read movement value, then move player.
        float Movement_Input = Player_Action_Controls.Gameplay.Movement.ReadValue<float>();

        Vector3 Current_Position = transform.position;

        Current_Position.x += Movement_Input * Move_Speed * Time.deltaTime;

        transform.position = Current_Position;

        // Animations:

        if (Movement_Input != 0)
        {
            Player_Animator.SetBool("Is_Walking", true);

        }

        else
        {
            Player_Animator.SetBool("Is_Walking", false);
        }

        //Sprite Flipping:

        if (Movement_Input < 0)
        {
            Player_Sprite_Renderer.flipX = false;
        }

        else if (Movement_Input >= 0)
        {
            Player_Sprite_Renderer.flipX = true;
        }
    }

    private void Dash_Increase()
    {
        Move_Speed = Move_Speed * 1.3f;
        Player_Action_Controls.Gameplay.Dash.canceled += Context => Dash_Decrease();
    }

    private void Dash_Decrease()
    {
        Move_Speed = Move_Speed / 1.3f;
    }
}
