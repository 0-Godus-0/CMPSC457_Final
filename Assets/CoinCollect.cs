using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GameObject coinTextPrefab; // Prefab for "+1 Coin" text
    public Transform canvas;         // Canvas for displaying UI

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add a coin to the tracker
            GameManager.instance.AddCoin();

            // Instantiate "+1 Coin" text
            GameObject coinText = Instantiate(coinTextPrefab, canvas);
            coinText.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
