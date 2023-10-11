using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Head : MonoBehaviour
{
    [SerializeField]
    public GameObject Enemy_Parent_Object;

    [SerializeField]
    private float Player_Jump_Boost_Value;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player_Feet"))
        {
            Player_Health_Script Player_Health = Collider.transform.parent.GetComponent<Player_Health_Script>();
            Rigidbody2D Player_Rigid_Body = Collider.transform.parent.GetComponent<Rigidbody2D>();

            if (Player_Rigid_Body != null)
            {
                Enemy_Parent_Object.gameObject.SetActive(false);
                Player_Rigid_Body.AddForce(Vector2.up * Player_Jump_Boost_Value, ForceMode2D.Impulse);
                //Player_Health.Lives += 1;
                //a life is stometimes taken from the player when killing the enemy. FIX THIS
            }
        }
    }
}
