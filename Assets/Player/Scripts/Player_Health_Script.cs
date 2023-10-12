using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health_Script : MonoBehaviour
{
    [SerializeField]
    public string Player_Colour;

    [SerializeField]
    public int Lives;

    [SerializeField]
    public TextMeshProUGUI Lives_Text;

    private void Update()
    {
        Update_Lives_Text();

        if (Lives <= 0)
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }

    private void Update_Lives_Text()
    {
        if (Lives_Text != null)
        {
            Lives_Text.text = Lives.ToString();
        }
    }
}
