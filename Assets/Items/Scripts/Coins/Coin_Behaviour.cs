using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Behaviour : MonoBehaviour
{
    [SerializeField]
    public int Coin_Value;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Player_Coins_Script Player_Coins = Collider.GetComponent<Player_Coins_Script>();
            if (Player_Coins != null)
            {
                Player_Coins.Coin_Count += 1;
                gameObject.SetActive(false);
            }
        }
        


    }

}
