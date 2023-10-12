using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Coins_Script : MonoBehaviour
{
    [SerializeField]
    public int Coin_Count;

    [SerializeField]
    public TextMeshProUGUI Coin_Count_Text;

    void Start()
    {
        Coin_Count = 0;
    }

    private void Update()
    {
        Coin_Count_Text.text = Coin_Count.ToString();
    }
}
