using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private int playerIndex = 0;

    private Rigidbody2D rb;
    private Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(inputVector.x, inputVector.y).normalized;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }
}
