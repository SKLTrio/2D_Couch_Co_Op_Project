using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Behaviour : MonoBehaviour
{
    [SerializeField]
    public string Win_Scene;

    [SerializeField]
    public int Coins_To_Collect = 20;

    [SerializeField]
    public TextMeshProUGUI Player_1_Coins_Text;

    [SerializeField]
    public TextMeshProUGUI Player_2_Coins_Text;

    [SerializeField]
    public TextMeshProUGUI Player_1_Not_Enough_Coins_Text;

    [SerializeField]
    public TextMeshProUGUI Player_2_Not_Enough_Coins_Text;

    private int Collected_Coins;

    private void Start()
    {
        Player_1_Not_Enough_Coins_Text.gameObject.SetActive(false);
        Player_2_Not_Enough_Coins_Text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {

            int Player_1_Coins = int.Parse(Player_1_Coins_Text.text);
            int Player_2_Coins = int.Parse(Player_2_Coins_Text.text);

            int Total_Player_Coins = Player_1_Coins + Player_2_Coins;

            if (Total_Player_Coins < Coins_To_Collect)
            {
                Player_1_Not_Enough_Coins_Text.gameObject.SetActive(true);
                Player_2_Not_Enough_Coins_Text.gameObject.SetActive(true);
            }

            else if (Total_Player_Coins == Coins_To_Collect)
            {
                SceneManager.LoadScene(Win_Scene);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player_1_Not_Enough_Coins_Text.gameObject.SetActive(false);
        Player_2_Not_Enough_Coins_Text.gameObject.SetActive(false);
    }
}
