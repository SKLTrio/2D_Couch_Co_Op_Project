using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
    private Player_Controls Player_Action_Controls;

    [SerializeField]
    private float Move_Speed = 5f;

    [SerializeField]
    private float Jump_Height = 3f;

    [SerializeField]
    private LayerMask Ground;

    [SerializeField]
    private int Player_Index = 0;

    [SerializeField] 
    public ParticleSystem Dust;

    private Rigidbody2D Rigid_Body;
    private Collider2D Player_Collider;

    [SerializeField]
    private Animator Player_Animator;
    private SpriteRenderer Player_Sprite_Renderer;
    private Vector2 Input_Vector = Vector2.zero;

    private void Awake()
    {
        Rigid_Body = GetComponent<Rigidbody2D>();
        Player_Collider = GetComponent<Collider2D>();
        Player_Animator = GetComponent<Animator>();
        Player_Sprite_Renderer = GetComponent<SpriteRenderer>();
        Player_Action_Controls = new Player_Controls();
    }

    public int Get_Player_Index()
    {
        return Player_Index;
    }

    public void Set_Input_Vector(Vector2 direction)
    {
        Input_Vector = direction;
    }

    void Start()
    {
        Player_Animator.SetBool("Is_Walking", false);
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(Input_Vector.x, Input_Vector.y).normalized;
        Rigid_Body.velocity = new Vector2(moveDirection.x * Move_Speed, Rigid_Body.velocity.y);

        if (moveDirection.x > 0)
        {
            Player_Sprite_Renderer.flipX = false;
            Player_Animator.SetBool("Is_Walking", true);
            Dust.Play();
        }
        if (moveDirection.x < 0)
        {
            Player_Sprite_Renderer.flipX = true;
            Player_Animator.SetBool("Is_Walking", true);
            Dust.Play();
        }

        if (moveDirection.x == 0)
        {
            Player_Animator.SetBool("Is_Walking", false);
        }    
    }

    public void Jump()
    {
        if (Is_Grounded())
        {
            Rigid_Body.AddForce(Vector2.up * Jump_Height, ForceMode2D.Impulse);
            Player_Animator.SetTrigger("Jump");
            Dust.Play();
        }
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

        return grounded;
    }
}
