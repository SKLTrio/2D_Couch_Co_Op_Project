using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Scene_Behaviour : MonoBehaviour
{

    public void Play_Again()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void Exit_Game()
    {
        Application.Quit();
    }
}
