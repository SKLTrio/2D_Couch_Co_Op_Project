using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    //This script is for the player stomping on and killing the enemy.

    [SerializeField]
    private float Player_Jump_Boost_Value;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Player_Health_Script Player_Health = Collider.gameObject.GetComponent<Player_Health_Script>();
            Rigidbody2D Player_Rigid_Body = Collider.GetComponent<Rigidbody2D>();
            if (Player_Rigid_Body != null && Player_Health != null)
            {
                //Enemy__Box_Collider.enabled = false;

                gameObject.SetActive(false);
                Player_Rigid_Body.AddForce(Vector2.up * Player_Jump_Boost_Value, ForceMode2D.Impulse);
                Player_Health.Lives += 1;
            }
        }
    }
}
