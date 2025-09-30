using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Variables moneda
    private int coins;
    public TMP_Text textcoins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            coins++;
            textcoins.text = coins.ToString();
        }
    }
}
