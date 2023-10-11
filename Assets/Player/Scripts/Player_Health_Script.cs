using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health_Script : MonoBehaviour
{
    [SerializeField]
    public int Lives;

    private void Update()
    {
        if (Lives <= 0)
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }

}
