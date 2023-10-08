using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
    private Player_C Player_Action_Controls;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpSpeed = 3f;

    [SerializeField]
    private LayerMask Ground;

    [SerializeField]
    private int playerIndex = 0;

    private Rigidbody2D rb;
    private Collider2D Player_Collider;
    private Animator Player_Animator;
    private SpriteRenderer Player_Sprite_Renderer;
    private Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player_Collider = GetComponent<Collider2D>();
        Player_Animator = GetComponent<Animator>();
        Player_Sprite_Renderer = GetComponent<SpriteRenderer>();
        Player_Action_Controls = new Player_C();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    void Start()
    {
        Player_Animator.SetBool("Is_Walking", false);
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(inputVector.x, inputVector.y).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        Move();

        // Check for jump input and if grounded, apply the jump force.
        if (Is_Grounded())
        {
            if (Player_Action_Controls.Player.Jump.triggered)
            {
                Jump();
            }
        }
    }

    public void Move()
    {
        // Read movement value, then move player.
        float Movement_Input = Player_Action_Controls.Player.Movement.ReadValue<float>();

        Vector3 Current_Position = transform.position;

        Current_Position.x += Movement_Input * moveSpeed * Time.deltaTime;

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
            Player_Sprite_Renderer.flipX = true;
        }
        else if (Movement_Input >= 0)
        {
            Player_Sprite_Renderer.flipX = false;
        }
    }

    public void Jump()
    {
        Debug.Log("Jump Performed!");
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        Player_Animator.SetTrigger("Jump");
    }

    public bool Is_Grounded()
    {
        Vector2 Top_Left_Point = transform.position;
        Top_Left_Point.x -= Player_Collider.bounds.extents.x;
        Top_Left_Point.y += Player_Collider.bounds.extents.y;

        Vector2 Bottom_Right_Point = transform.position;
        Bottom_Right_Point.x += Player_Collider.bounds.extents.x;
        Bottom_Right_Point.y -= Player_Collider.bounds.extents.y;

        bool grounded = Physics2D.OverlapArea(Top_Left_Point, Bottom_Right_Point, Ground);

        // Debugging: Output the result of the grounded check to the console.
        if (grounded)
        {
            Debug.Log("Grounded");
        }
        else
        {
            Debug.Log("Not Grounded");
        }

        return grounded;
    }
}
