using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health_Script : MonoBehaviour
{
    [SerializeField] public int Lives;

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Enemy_Purple"))
        {
            Lives -= 1;
        }

        else if (Collider.CompareTag("Enemy_Blue"))
        {
            Lives = 0;
        }

        if (Lives <= 0)
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }
}
