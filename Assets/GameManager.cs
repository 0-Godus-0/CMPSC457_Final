using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public TextMeshProUGUI coinText;    // UI element for coin count
    public TextMeshProUGUI winText;     // UI element for "You Win" message

    private int coinCount = 0;          // Track the number of coins collected
    private int winThreshold = 10;     // Number of coins needed to win
    private bool gameEnded = false;    // Flag to prevent multiple EndGame calls

    void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(false); // Ensure "You Win" text is hidden at start
        }
    }

    // Method to increase coin count
    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();
        CheckWinCondition();
    }

    // Method to decrease coin count
    public void RemoveCoin()
    {
        if (coinCount > 0)
        {
            coinCount--;
            UpdateCoinUI();
        }
    }

    // Update the coin count text in the UI
    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }

    // Check if the player has reached the win condition
    private void CheckWinCondition()
    {
        if (coinCount >= winThreshold && !gameEnded)
        {
            EndGame();
        }
    }

    // End the game and display "You Win"
    private void EndGame()
    {
        Debug.Log("EndGame method called."); // Debug log for tracking

        gameEnded = true; // Set the flag to prevent multiple calls

        if (winText != null)
        {
            winText.gameObject.SetActive(true); // Display the "You Win" message
            Debug.Log("You Win text displayed."); // Debug log for text activation
        }
        else
        {
            Debug.LogError("WinText is not assigned in the GameManager."); // Debug log if winText is missing
        }

        // Add a delay before pausing the game
        StartCoroutine(DelayedPause());
    }

    private IEnumerator DelayedPause()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before pausing
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game paused."); // Debug log for pausing the game
    }
}
