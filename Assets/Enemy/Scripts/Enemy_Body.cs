using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy_Body : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Put the enemy's colour here!")]
    public string Enemy_Colour;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Debug.Log("Player found!");
            Player_Health_Script Player_Health = Collider.GetComponent<Player_Health_Script>();

            if (Player_Health != null)
            {
                if (Enemy_Colour == "Purple")
                {
                    Player_Health.Lives -= 1;
                    Debug.Log("1 Life Taken!");
                }

                else if (Enemy_Colour == "Blue")
                {
                    Player_Health.Lives -= 1;
                    Debug.Log("1 Life Taken");
                }

                else
                {
                    Player_Health.Lives = 0;
                    SceneManager.LoadScene("Main_Scene");
                }
            }

            else
            {
                Debug.Log("Player_Health is not found!");
            }
        }
    }

}
