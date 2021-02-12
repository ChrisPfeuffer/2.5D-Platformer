using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int score;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            Player player = other.GetComponent<Player>();

            if(player != null){
                player.AddCoins();
            }
            Destroy(this.gameObject);
        }
    }

}
