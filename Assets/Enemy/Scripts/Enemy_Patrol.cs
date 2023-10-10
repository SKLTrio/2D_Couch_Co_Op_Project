using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [SerializeField]
    public Vector2 Point_1, Point_2;

    [SerializeField]
    public Animator Enemy_Animator;

    [SerializeField]
    public SpriteRenderer Enemy_Sprite;

    [SerializeField]
    public float Move_Speed;

    private Vector2 Target_Point;

    void Start()
    {
        Target_Point = Point_1;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target_Point, Move_Speed * Time.deltaTime);
        Enemy_Animator.SetBool("Is_Walking", true);

        if (Vector2.Distance(transform.position, Target_Point) < 0.1f)
        {
            Switch_Point();
        }
    }

    private void Switch_Point()
    {
        if (Target_Point == Point_1)
        {
            Target_Point = Point_2;
            Enemy_Sprite.flipX = false;
        }

        else
        {
            Target_Point = Point_1;
            Enemy_Sprite.flipX = true;
        }
    }
}
