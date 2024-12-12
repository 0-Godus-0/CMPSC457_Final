using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class FadeAndDestroy : MonoBehaviour
{
    public float duration = 1f; // Time for the text to fade out

    private TextMeshProUGUI textComponent; // Reference to the TextMeshPro component
    private float timer;

    void Start()
    {
        // Get the TextMeshProUGUI component
        textComponent = GetComponent<TextMeshProUGUI>();

        if (textComponent == null)
        {
            Debug.LogError("No TextMeshProUGUI component found! Ensure the object has a TextMeshProUGUI component.");
            return;
        }

        timer = duration; // Initialize the timer
    }

    void Update()
    {
        if (textComponent == null) return; // Exit if TextMeshProUGUI is not found

        // Decrease the timer
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject); // Destroy the text object when timer ends
        }
        else
        {
            // Gradually reduce the alpha of the text
            Color color = textComponent.color;
            color.a = Mathf.Lerp(0, 1, timer / duration);
            textComponent.color = color;
        }
    }
}
