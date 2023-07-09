using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int CoinsNumber = 0;
    public TextMeshProUGUI CoinsText;

    private void Update()
    {
        UpdateCoinsText();
    }



    private void UpdateCoinsText()
    {
       
        CoinsText.text = "Coins: " + CoinsNumber.ToString();
        Debug.Log(CoinsText);
    }

}
