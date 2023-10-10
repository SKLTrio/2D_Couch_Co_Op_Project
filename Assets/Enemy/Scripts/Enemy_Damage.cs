using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    //This script is for the enemy damaging the player's lives.

    //This is triggering both colliders to act as a trigger, instead of the specific kill collider for the player. That collider is acting as the one making the enemy die.
    //FIX THIS!!!
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            gameObject.SetActive(false); 
        }
    }
}
