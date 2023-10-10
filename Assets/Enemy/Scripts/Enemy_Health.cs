using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField]
    public BoxCollider2D Enemy_Box_Collider;

    //[SerializeField]
    //public CircleCollider2D Enemy_Circle_Collider;

    [SerializeField]
    private float Player_Jump_Boost_Value;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Rigidbody2D Player_Rigid_Body = Collider.GetComponent<Rigidbody2D>();
            if (Player_Rigid_Body != null)
            {
                Player_Rigid_Body.AddForce(Vector2.up * Player_Jump_Boost_Value, ForceMode2D.Impulse);
            }


            gameObject.SetActive(false);
        }
    }
}
