using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _coinText;
    [SerializeField] Text _livesText;

    public void UpdateCoinDisplay(int coins){
        _coinText.text = "Coins: " + coins.ToString();
    }

    public void UpdateLivesDisplay(int lives){
        _livesText.text = "Lives: " + lives.ToString();
    }
}
